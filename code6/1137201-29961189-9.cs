        private void timer1_Tick(object sender, EventArgs e)
        {
           pictureBox1.Invalidate();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            argb += 1;
            e.Graphics.Clear(Color.FromArgb(argb));
        }
