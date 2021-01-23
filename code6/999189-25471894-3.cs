    public bool Check(double x, double y)
    {
        return ((x - 0.5) * (x - 0.5) + (y - 0.5) * (y - 0.5)) < 0.25;    
    }
    // ...
    N_0 = Enumerable
        .Range(0, n)
        .Select(i => new { X = rnd.NextDouble(), Y = rnd.NextDouble() })
        .AsParallel()
        .Count(p => Check(p.X, p.Y));
