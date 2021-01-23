    var sledRacing = new[] { 100, 102, 103, 100, 100, 102, 101 };
    var lu = sledRacing.ToLookup(
            k => k,
            k => k == 100 ? new string[3] : (k == 101 ? new string[2] : new string[1])
        );
    foreach (var g in lu)
    {
        Console.WriteLine(g.Key);
        foreach (var i in g)
        {
            Console.WriteLine("  - " + i.Length);
        }
    }
