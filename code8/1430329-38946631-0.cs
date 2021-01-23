        private void Form1_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (debug == true)
                {
                    MessageBox.Show("CURSOR UP", "Cursor!");
                }
                pictureBox1.Image = Properties.Resources.key_up_pressed;
                pictureBox1.Refresh();
            }
        }
