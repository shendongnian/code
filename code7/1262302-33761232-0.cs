    double d1 = double.MaxValue;
    double d2 = double.MaxValue;
    double d3 = d1*d2;
    if (double.IsInfinity(d3))
        Console.WriteLine("Infinity");
    if (double.IsPositiveInfinity(d3))
        Console.WriteLine("Positive Infinity");
    d1 = double.MinValue;
    d2 = double.MaxValue;
    d3 = d1*d2;
    if (double.IsInfinity(d3))
        Console.WriteLine("Infinity");
    if (double.IsNegativeInfinity(d3))
        Console.WriteLine("Negative Infinity");
