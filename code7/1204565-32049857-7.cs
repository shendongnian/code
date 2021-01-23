    Random R = new Random(2015);  // I prefer repeatable randoms
    List<PointF> points = new List<PointF>();  // charts actually uses double by default
    List<Point> lines = new List<Point>();
    int pointCount = 100;
    int lineCount = 25;
    for (int i = 0; i < pointCount; i++)
        points.Add(new PointF(1 + R.Next(100), 1 + R.Next(50)));
    for (int i = 0; i < lineCount; i++)
        lines.Add(new Point(R.Next(pointCount), R.Next(pointCount)));
