    List<int> numlist = Enumerable.Range(1, 10).ToList();// generating list
    List<double> avelist = new List<double>();
    Dictionary<int, double> rollingAvg = new Dictionary<int, double>();
    int limit = 4, i = 0;
    while (limit + i <= numlist.Count)
    {
        avelist.Add(numlist.Skip(i).Take(limit).Average());
        i++;
    }
