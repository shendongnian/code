        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = false;
            timer1.Enabled = false;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Visible = true;
            timer1.Enabled = true; //will wait timer1.interval milliseconds then run tick           
        }
