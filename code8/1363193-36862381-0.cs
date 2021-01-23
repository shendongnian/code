    List<double> avelist = new List<double>() { 2.5, 3.5, 4.5, 5.5, 6.5, 7.5 };
    Dictionary<int, double> rollingAvg = new Dictionary<int, double>();
    int limit = 4, i = 0; // specify the limit here
    while (limit + i <= avelist.Count)
    {
        rollingAvg.Add(i, avelist.Skip(i).Take(limit).Average());
        i++;
    }
