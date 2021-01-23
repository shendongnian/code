    public List<string> SortList(List<string> thread)
    {
        var first = thread.Take(1);
        var ordered = thread.Skip(1).OrderBy(s=>char.GetNumericValue(s[0]));
        return first.Concat(ordered).ToList();
    }
