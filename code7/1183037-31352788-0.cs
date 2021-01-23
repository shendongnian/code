        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Point pt = new Point(pictureBox1.Width / 2 - pictureBox1.Image.Width / 2, pictureBox1.Height / 2 - pictureBox1.Image.Height / 2);
            Rectangle rc = new Rectangle(pt, pictureBox1.Image.Size);
            e.Graphics.DrawRectangle(Pens.Red, rc);
        }
