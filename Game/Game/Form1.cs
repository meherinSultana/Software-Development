using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form

    {
        bool goLeft, goRight, jumping, isGameOver;
        int jumpSpeed;
        int force;
        int score = 0;
        int playerspeed = 7;
        int horizontalSpeed = 5;
        int verticalSpeed = 4;
        int enemy1Speed = 3;
        int enemy2Speed = 3;
        int enemy3Speed = 3;
        int enemy4Speed = 3;
        int enemy5Speed = 2;

        public Form1()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            TxtScore.Text = "Score: " + score;
            Playe.Top += jumpSpeed;

            if(goLeft == true)
            {
                Playe.Left -= playerspeed;
            }
            if (goRight == true)
            {
                Playe.Left += playerspeed;
            }
            if(jumping== true && force < 0)
            {
                jumping = false;
            }
            if(jumping == true)
            {
                jumpSpeed = -8;
                force -= 1;
            }
            else
            {
                jumpSpeed = 10;
            }
            foreach(Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if((string)x.Tag == "Platform")
                    {
                        if(Playe.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            Playe.Top = x.Top - Playe.Height;

                            if ((string)x.Name == "horizontalPlatform" && goLeft == false || (string)x.Name == "horizontalPlatform" && goRight == false)
                            {
                                Playe.Left -= horizontalSpeed;
                            }
                        }
                        x.BringToFront();
                    }
                    if ((string)x.Tag == "coin")
                    {
                        if (Playe.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }

                    if ((string)x.Tag == "enemy")
                    {
                        if (Playe.Bounds.IntersectsWith(x.Bounds))
                        {
                            timer1.Stop();
                            isGameOver = true;
                            TxtScore.Text = "Score: " + score + Environment.NewLine + "You were killed in your journey!!";
                            RestartGame();
                        }
                    }

                }
            }
            horizontalPlatform.Left -= horizontalSpeed;

            if (horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }

            verticalPlatform.Top += verticalSpeed;

            if (verticalPlatform.Top < 400 || verticalPlatform.Top > 555)
            {
                verticalSpeed = -verticalSpeed;
            }

            enemy1.Left -= enemy1Speed;

            if (enemy1.Left < pictureBox3.Left || enemy1.Left + enemy1.Width > pictureBox3.Left + pictureBox3.Width)
            {
                enemy1Speed = -enemy1Speed;
            }

            enemy2.Left += enemy2Speed;

            if (enemy2.Left < pictureBox4.Left || enemy2.Left + enemy2.Width > pictureBox4.Left + pictureBox4.Width)
            {
                enemy2Speed = -enemy2Speed;
            }

            enemy3.Left -= enemy3Speed;

            if (enemy3.Left < pictureBox6.Left || enemy3.Left + enemy3.Width > pictureBox6.Left + pictureBox6.Width)
            {
                enemy3Speed = -enemy3Speed;
            }

            enemy4.Left += enemy4Speed;

            if (enemy4.Left < pictureBox9.Left || enemy4.Left + enemy4.Width > pictureBox9.Left + pictureBox9.Width)
            {
                enemy4Speed = -enemy4Speed;
            }

            enemy5.Left -= enemy5Speed;

            if (enemy5.Left < pictureBox10.Left || enemy5.Left + enemy5.Width > pictureBox10.Left + pictureBox10.Width)
            {
                enemy5Speed = -enemy5Speed;
            }


            if (Playe.Top + Playe.Height > this.ClientSize.Height + 50)
            {
                timer1.Stop();
                isGameOver = true;
                TxtScore.Text = "Score: " + score + Environment.NewLine + "You fell to your death!";
                RestartGame();
            }

            if (Playe.Bounds.IntersectsWith(door.Bounds) && score == 44)
            {
                timer1.Stop();
                isGameOver = true;
                TxtScore.Text = "Score: " + score + Environment.NewLine + "Your quest is complete!";
            }
            else
            {
                TxtScore.Text = "Score: " + score + Environment.NewLine + "Collect all the coins";
            }

        }


        private void pictureBox62_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox61_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void player(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (jumping == true)
            {
                jumping = false;
            }
           
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                RestartGame();
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }
        private void RestartGame()
        {

            jumping = false;
            goLeft = false;
            goRight = false;
            isGameOver = false;
            score = 0;
            TxtScore.Text = "Score: " + score;
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && x.Visible==false)
                {
                    x.Visible = true;
                }
            }

            Playe.Left = 39;
            Playe.Top = 614;
            enemy1.Left = 577;
            enemy2.Left = 351;
            enemy3.Left = 190;
            enemy4.Left = 571;
            enemy5.Left = 154;
            horizontalPlatform.Left = 328;
            verticalPlatform.Top = 555;
            timer1.Start();

        }
    }
}
