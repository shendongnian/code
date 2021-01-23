    Point bary = Point.Zero;
    foreach (Point p in list)
    {
        bary.X += p.X;
        bary.Y += p.Y;
    }
    bary.X = (bary.X + list.Count / 2) / list.Count;
    bary.Y = (bary.Y + list.Count / 2) / list.Count;
    return bary;
