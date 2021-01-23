    static public int Q()
    {
        var e = Enumerable.Range(0, 100)
            .Select(i => i);
    
        Contract.Assume(e.Count() > 0);
        return e.First();
    }
