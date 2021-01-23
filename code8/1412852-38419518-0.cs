    List<Point> allPoints = new List<Point>();
    Point mDown = Point.Empty;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        mDown = e.Location;
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        allPoints.Add(e.Location);
        pictureBox1.Invalidate();
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button.HasFlag(MouseButtons.Left))
        {
            pictureBox1.Refresh();
            using (Graphics G = pictureBox1.CreateGraphics())
                G.DrawLine(Pens.Red, mDown, e.Location);
        }
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (allPoints.Count > 1) e.Graphics.DrawLines(Pens.Black, allPoints.ToArray());
    }
