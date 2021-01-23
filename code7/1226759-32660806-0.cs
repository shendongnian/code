    public IEnumerable<Point> GetPoints(Point origin, IEnumerable<Point> points, int distance)
    {
        var result = new HashSet<Point>();
        var found = new Queue<Point>();
        found.Enqueue(origin)
        while(found.Count > 0)
        {
            var current = found.Dequeue();
            var candidates = points
                .Where(p => !result.Contains(p) &&
                       p.Distance(current) <= distance);
            foreach(var p in candidates)
            {
                result.Add(p);
                found.Enqueue(p)
            }
        }
        return result;
    }
