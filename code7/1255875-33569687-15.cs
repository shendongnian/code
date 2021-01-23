    Point mCurrent = Point.Empty;
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        mCurrent = e.Location;
        Invalidate();
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        mDown = Point.Empty;
        mCurrent = Point.Empty;
        Invalidate();
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        if (Control.MouseButtons == System.Windows.Forms.MouseButtons.Left)
        {
            Rectangle rect = rectangle(mDown, mCurrent);
            // either one..
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(32, 255, 0, 0)))
                e.Graphics.FillRectangle(brush, rect);
            // ..or both of these
            e.Graphics.DrawRectangle(Pens.Red, rect);
        }
    }
