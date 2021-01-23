    foreach (Point pt in points)
    {
        using(Pen p = new Pen(Color.Tomato, 2))
        using(SolidBrush myb = new SolidBrush(Color.White))
        {
            g.FillEllipse(myb, pt.X, pt.Y, 20, 20);
            g.DrawEllipse(p, pt.X, pt.Y, 20, 20);
        }
    }
