    Point mDown = Point.Empty;
    float fSize = 12f;
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        using (Font font = new Font("Consolas", fSize))
            e.Graphics.DrawString("Hello World", font, Brushes.Black, mDown);
    }
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        mDown = e.Location;
        pictureBox1.Invalidate();
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        fSize = Math.Abs(e.Y - mDown.Y) / 2f + 1;
        pictureBox1.Invalidate();
    }
