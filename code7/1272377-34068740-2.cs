    List<Point> points = new List<Point>();
    points.Add(new Point(1, 1));
    points.Add(new Point(1, 1));
    points.Add(new Point(1, 1));
    points.Add(new Point(1, 2));
    points.Add(new Point(1, 2));
    points.Add(new Point(1, 2));
    
    List<Point> goodPoints = new List<Point>();
    
    
    foreach (Point p in points)
    {
        goodPoints.Add(p);
        goodPoints = goodPoints.Distinct().ToList();
        int idx = goodPoints.IndexOf(p);
        Debug.WriteLine(string.Format("Index of Point({0}, {1}) = {2}", p.X, p.Y, idx));
    }
