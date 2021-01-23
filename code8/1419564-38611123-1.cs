    List<double> doubleTest = new List<double>()
    {
        0,
        12233302.4,
        double.NegativeInfinity,
        double.PositiveInfinity,
    	5
    };
    
    doubleTest.RemoveAll(item => double.IsInfinity(item) || item == 0);
