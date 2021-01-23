    Path makePath(params Point[] points)
    {
        Path path = new Path()
        {
            Stroke = Brushes.Black,
            StrokeThickness = 1
        };
        if (points.Length == 0)
            return path;
        PathSegmentCollection pathSegments = new PathSegmentCollection();
        for (int i = 1; i < points.Length; i++)
            pathSegments.Add(new LineSegment(points[i], true));
        path.Data = new PathGeometry()
        {
            Figures = new PathFigureCollection()
            {
                new PathFigure()
                {
                    StartPoint = points[0],
                    Segments = pathSegments
                }
            }
        };
        return path;
    }
