        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            // with MouseHover this control appears to be locked until you move mouse elsewhere (thus releasing it)
            pictureBox2.Visible = false;
            pictureBox2.BackColor = Color.Black;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {            
            pictureBox2.Visible = true;
        }
