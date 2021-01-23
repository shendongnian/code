    List<Point> points = new List<Point>();
    points.Add(new Point(1, 1));
    points.Add(new Point(1, 1));
    points.Add(new Point(1, 1));
    points.Add(new Point(2, 1));
    points.Add(new Point(2, 1));
    points.Add(new Point(2, 1));
    
    Debug.WriteLine(string.Format("Unique: {0}", 
        points.Select(x => x).Distinct().ToList<Point>().Count.ToString()));
