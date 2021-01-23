    double x = veryHighNumber * 2 * 0.5;
    
    double terriblyHighNumber = veryHighNumber * 2;
    double x2 = terriblyHighNumber * 0.5;
    
    Debug.Assert(!Double.IsInfinity(x));
    Debug.Assert(Double.IsInfinity(x2));
    Debug.Assert(x != x2);
