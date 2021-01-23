    var points = new[] { 2.1, 2.2, 2.6, 4, 4.2, 4.7, 4.8 };
    var groups = new Dictionary<double, List<double>>();
    foreach (var p in points)
    {
        var intp = (double)((int)p);
        if (p - intp < .5)
        {
            if (!groups.ContainsKey(intp))
            {
                groups[intp] = new List<double>();
            }
            groups[intp].Add(p);
        }
        else
        {
            groups[p] = new List<double> { p };
        }
    }
    points = groups.Select(dict => dict.Value.Average()).ToArray();
    var averages = String.Join(",", points.Select(p => p.ToString()));
    Console.WriteLine(averages);
    
