    public static IList<string> Merge(params IList<string>[] lists)
    {
        return Merge((IList<IList<string>>) lists);
    }
    
    public static IList<string> Merge(IList<IList<string>> lists, int offset = 0)
    {
        if (offset >= lists.Count)
            return new List<string>();
    
        var current = lists[offset];
        if (offset + 1 == lists.Count) // last entry in lists
            return current;
    
        var retval = new List<string>();
    
        var merged = Merge(lists, offset + 1);
        foreach (var x in current)
        {
            retval.AddRange(merged.Select(y => string.Format("{0}_{1}", x, y)));
        }
    
        return retval;
    }
