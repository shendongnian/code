    foreach(Point point in points)
    {
      point.X = point.X + 3;
      point.Y = 17;
    }
    
    for(int i = 1; i < points.Count; i++)
      points[i].X = points[i-1].X + 3;
