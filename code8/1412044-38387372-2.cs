    using MathNet.Numerics.RootFinding;
    ...
    var roots = Cubic.RealRoots(d, c, b); // "a" is assumed to be 1
    double root1 = roots.Item1;
    double root2 = roots.Item2;
    double roo13 = roots.Item3;
