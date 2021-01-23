    double x0, y0, r;
    FitCircle(surfacePoints, out x0, out y0, out r);
    var center = new Point(x0, y0, surfacePoints.First().Z);
    int reductionIterations = 10;
    var reducedSet = surfacePoints;
    for (int i = 1; i < reductionIterations; i++)
    {
        var orderedByDistanceToCenter = reducedSet.OrderBy(p => (p-center).GetRho()).ToList();
        reducedSet = orderedByDistanceToCenter
            .Skip((int)(orderedByDistanceToCenter.Count * (i / 10f)))
            .Take((int)(orderedByDistanceToCenter.Count - orderedByDistanceToCenter.Count * (i / 10f)*2))
            .ToList();
        // Reduced to zero, abort
        if (reducedSet.Count < 3)
            break;
        FitCircle(reducedSet, out x0, out y0, out r);
        center = new Point(x0, y0, reducedSet.First().Z);
    }
    public static double GetRho(this Point p) => Math.Sqrt(p.X * p.X + p.Y * p.Y);
