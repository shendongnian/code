    static List<Segment> Segmentize(Bitmap blackAndWhite)
    {
        var bawa = new BitmapWithAccess(blackAndWhite, System.Drawing.Imaging.ImageLockMode.ReadOnly);
        var result = new List<Segment>();
          
        HashSet<Point> queue = new HashSet<Point>();
        bool[,] visitedPoints = new bool[blackAndWhite.Width, blackAndWhite.Height];
        for (int x = 0;x < blackAndWhite.Width;++x)
            for (int y = 0;y < blackAndWhite.Height;++y)
            {
                if (bawa.GetPixel(x, y).A != 0
                    && !visitedPoints[x, y])
                {
                    result.Add(BuildSegment(new Point(x, y), bawa, visitedPoints));
                }
            }
        bawa.Release();
        return result;
    }
    static Segment BuildSegment(Point startingPoint, BitmapWithAccess bawa, bool[,] visitedPoints)
    {
        var result = new Segment();
        List<Point> toProcess = new List<Point>();
        toProcess.Add(startingPoint);
        while (toProcess.Count > 0)
        {
            Point p = toProcess.First();
            toProcess.RemoveAt(0);
            ProcessPoint(result, p, bawa, toProcess, visitedPoints);
        }
        return result;
    }
    static void ProcessPoint(Segment segment, Point point, BitmapWithAccess bawa, List<Point> toProcess, bool[,] visitedPoints)
    {
        for (int i = -1; i <= 1; ++i)
        {
            for (int j = -1; j <= 1; ++j)
            {
                int x = point.X + i;
                int y = point.Y + j;
                if (x < 0 || y < 0 || x >= bawa.Bitmap.Width || y >= bawa.Bitmap.Height)
                    continue;
                if (bawa.GetPixel(x, y).A != 0 && !visitedPoints[x, y])
                {
                    segment.Left = Math.Min(segment.Left, x);
                    segment.Right = Math.Max(segment.Right, x);
                    segment.Top = Math.Min(segment.Top, y);
                    segment.Bottom = Math.Max(segment.Bottom, y);
                    toProcess.Add(new Point(x, y));
                    visitedPoints[x, y] = true;
                }
            }
        }
    }
