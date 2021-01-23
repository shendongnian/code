    private Point[] CreatePoints(params string[] points)
    {
        List<Point> result = new List<Point>();
        foreach(var s in points)
        {
            var parts = s.Split(',');
            var x = Double.Parse(parts[0]);
            var y = Double.Parse(parts[1]);            
            var point = new Point(x,y);
            result.Add(point);
        }
        return result.ToArray();
    }
