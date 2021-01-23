    float radius = 200;           PointF center = new PointF(480,360);
    PointF pt1 = PointF.Empty;    PointF pt2 = PointF.Empty;
    List<PointF> pointsM = new List<PointF>();
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {   
        if (e.Button == MouseButtons.Left)
        {   // drag around and watch the points
            pt2 = e.Location;
            pointsM = Intersections(center, radius, pt1, pt2, false);
            Invalidate();
        }
    }
    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {   // right-click to set the first point
        if (e.Button == MouseButtons.Right) pt1 = e.Location;
        Invalidate();
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawEllipse(Pens.Blue, center.X - radius, center.Y - radius, 
                               radius * 2, radius * 2);
        e.Graphics.DrawLine(Pens.Green, pt1, pt2);
        e.Graphics.FillEllipse(Brushes.Blue, center.X - 4, center.Y - 4, 8, 8);
        foreach (PointF pt in pointsM)
            e.Graphics.FillEllipse(Brushes.DarkOrange, pt.X - 4, pt.Y - 4, 8, 8);
        e.Graphics.FillEllipse(Brushes.Green, pt1.X - 4, pt1.Y - 4, 8, 8);
        e.Graphics.FillEllipse(Brushes.DeepPink, pt2.X - 4, pt2.Y - 4, 8, 8);
        Text = pointsM.Count + " intersection points.";
    }
