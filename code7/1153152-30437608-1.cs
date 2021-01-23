    Point mDown = Point.Empty;
    Point mCurr = Point.Empty;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {   mDown = e.Location;  }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
           { mCurr = e.Location; pictureBox1.Invalidate(); }
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        Rectangle r = new Rectangle(mDown.X, mDown.Y, mCurr.X - mDown.X, mCurr.Y - mDown.Y);
        e.Graphics.DrawRectangle(Pens.Orange, r);
        pictureBox2.Invalidate();
    }
    private void pictureBox2_Paint(object sender, PaintEventArgs e)
    {
        if (pictureBox2.Image == null) return;
        float stretch1X = 1f * pictureBox1.Image.Width / pictureBox1.ClientSize.Width;
        float stretch1Y = 1f * pictureBox1.Image.Height / pictureBox1.ClientSize.Height;
        int x = (int)(mDown.X * stretch1X);
        int y = (int)(mDown.Y * stretch1Y);
        int x2 = (int)(mCurr.X * stretch1X);
        int y2 = (int)(mCurr.Y * stretch1Y);
        Rectangle r = new Rectangle(x, y, x2 - x, y2 - y);
        e.Graphics.DrawRectangle(Pens.Orange, r);
    }
