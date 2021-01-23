    var dict = new Dictionary<int, Tuple<int, double>>();
    foreach (var g in i)
    {
        var id = g.Id;
        Tuple<int, double> t;
        if (!dict.ContainsKey(id))
            dict.Add(id, t = Tuple.Create(0, 0.0));
        else
            t = dict[id];
        var c = t.Item1 + 1;
        dict[id] =  Tuple.Create(c, (t.Item2 * t.Item1 + g.Marks) / c);
    }
    double best = 0.0;
    foreach (var g in dict)
    {
        var m = g.Value.Item2;
        if (best < m)
            best = m;
    }
    // best = 84.0
