    List<Point> redPoints = new List<Point>();
    List<Point> blackPoints = new List<Point>();
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        if (radioButton1.Checked)
            redPoints.Add(e.Location);
        else
            blackPoints.Add(e.Location);
        panel1.Invalidate();
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        int count = 0;
        Graphics g = e.Graphics;
        foreach (Point p in redPoints)
        {
            g.FillEllipse(Brushes.Red, p.X, p.Y, 10, 10);
        }
        foreach (Point p in blackPoints)
        {
            g.FillEllipse(Brushes.Black, p.X, p.Y, 10, 10);
        }
    }
