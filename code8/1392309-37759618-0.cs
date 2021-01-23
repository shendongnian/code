    private IList<Point> points = new List<Point>();
    public IEnumerable<Point> Points => points;
    public void AddPoint(Point p) {
        // validate p before inserting on the list,
        ...
        points.Add(p);
    }
