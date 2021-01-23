    private static Rectangle[] SplitPointsIntoRectangles(Point[] pa)
    {
        pa = pa.OrderBy(p => p.X).ToArray();
        Point[] leftmost = pa.Select(p => p).Where(p => p.X == pa[0].X).ToArray();
        Point[] rightmost = pa.Select(p => p).Where(p => p.X == pa[pa.Length - 1].X).ToArray();
        pa = pa.OrderBy(p => p.Y).ToArray();
        Point[] topmost = pa.Select(p => p).Where(p => p.Y == pa[0].Y).ToArray();
        Point[] bottommost = pa.Select(p => p).Where(p => p.Y == pa[pa.Length - 1].Y).ToArray();
        List<Point> edges = new List<Point>();
        edges.AddRange(leftmost);
        edges.AddRange(rightmost);
        edges.AddRange(topmost);
        edges.AddRange(bottommost);
        Point middlePixel = pa.FirstOrDefault(p => !edges.Contains(p));
        Rectangle[] ra = new Rectangle[2];
        ra[0] = new Rectangle(leftmost[0].X, leftmost.Min(p => p.Y), rightmost[0].X - leftmost[0].X, bottommost[0].Y - leftmost[0].Y);
        ra[1] = new Rectangle(topmost.Min(p => p.X), topmost[0].Y, rightmost[0].X - middlePixel.X, middlePixel.Y - topmost[0].Y);
        return ra;
    }
