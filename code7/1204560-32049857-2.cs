    foreach (Point ln in lines)
    {
        int p0 = SL.Points.AddXY(points[ln.X].X, points[ln.X].Y);
        int p1 = SL.Points.AddXY(points[ln.Y].X, points[ln.Y].Y);
        SL.Points[p0].Color = Color.Transparent;
        SL.Points[p1].Color = Color.OrangeRed;
    }
