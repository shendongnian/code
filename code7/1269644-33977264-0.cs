    List<Point> sub = new List<Point>();
    _destinations.ForEach(item => sub.Add(new Point(item.X - deliver.X, item.Y - deliver.Y)));
                
    sub.Sort((a, b) =>
    {
        double d1 = Math.Pow(a.X, 2) + Math.Pow(a.Y, 2);
        double d2 = Math.Pow(b.X, 2) + Math.Pow(b.Y, 2);
        return d1.CompareTo(d2);
    });
    
    List<Point> sorted = new List<Point>();
    sub.ForEach(item => sorted.Add(new Point(item.X + deliver.X, item.Y + deliver.Y)));
