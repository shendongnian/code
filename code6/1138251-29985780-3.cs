    var comparer = new CachingEqualityComparer<string>();
    var hs = new HashSet<string>(comparer);
    string str = "Hello";
    string st1 = str.Substring(2);
    hs.Add(st1);
    string st2 = str.Substring(2);
    // st1 and st2 are distinct strings!
    if (object.ReferenceEquals(st1, st2))
    {
        throw new Exception();
    }
    comparer.Reset();
    if (hs.Contains(st2))
    {
        string cached = comparer.Other(st2);
        Console.WriteLine("Found!");
        // cached is st1
        if (!object.ReferenceEquals(cached, st1))
        {
            throw new Exception();
        }
    }
