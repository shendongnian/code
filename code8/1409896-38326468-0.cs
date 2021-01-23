    foreach (Point pt in points)
    {
        Pen p = new Pen(Color.Tomato, 2);
        SolidBrush myb = new SolidBrush(Color.White);
        g.DrawEllipse(p, pt.X, pt.Y, 20, 20);
        g.FillEllipse(myb, pt.X, pt.Y, 20, 20);
        p.Dispose();
    }
