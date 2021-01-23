        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = false;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Visible = true;
            timer1.Enabled = true;            
        }
