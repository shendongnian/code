    List<Point> points = new List<Point>  { new Point(0,0), new Point(1,1), new Point(2,2) };
    for (int i = 0; i < points.Count; i++)
    {
        Point p = points[i];
        p.X += 1;
        //and don't forget update the old value, because we're using copy
        points[i] = p;
    }
