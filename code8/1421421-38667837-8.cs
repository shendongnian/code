    var dict = new Dictionary<int, List<double>>();
    foreach (var g in i )
    {
        var id = g.Id;
        if (!dict.ContainsKey(id))
            dict.Add(id, new List<double>());
        dict[id].Add(g.Marks);
    }
    double best = 0.0;
    foreach (var g in dict)
    {
        var totalmarks = 0.0;
        foreach (var mark in g.Value)
        {
            totalmarks += (double)mark;
        }
        var average = totalmarks / g.Value.Count;
        if (best < average)
            best = average;
    }
    // best = 84.0
