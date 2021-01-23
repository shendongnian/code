        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            // with MouseHover this control visibility appears to be locked with MouseEnter it is not
            pictureBox2.Visible = false;
            pictureBox2.BackColor = Color.Black;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {            
            pictureBox2.Visible = true;
        }
