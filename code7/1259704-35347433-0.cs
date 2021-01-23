    List<Point2f> points = new List<Point2f>();
    points.Add(new Point2f(3, 3));
    points.Add(new Point2f(4, 4));
    points.Add(new Point2f(5, 5));
    Line2D line = Cv2.FitLine(points, DistanceTypes.L2, 0, 0.01, 0.01);
