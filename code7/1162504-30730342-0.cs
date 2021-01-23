    Point mDown = Point.Empty;
    private void pbMove_MouseDown(object sender, MouseEventArgs e)
    {  mDown = e.Location;  }
    private void pbMove_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Size sz = new Size(mDown.X - e.X, mDown.Y - e.Y);
            pbMove.Location = Point.Subtract(pbMove.Location, sz);
        }
    }
