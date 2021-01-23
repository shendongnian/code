    public IEnumerable<string> GetLongestStrings(params string[] strings)
    {
        //returns first string with largest length out of given argumenst
        int maxSize = strings.Max(str => str.Length);
        return strings.Where(s => s.Length == maxSize);
    }
    public IEnumerable<string> GetShortestStrings(params string[] strings)
    {
        //returns first string with shortest length out of given arguments
        int minSize = strings.Min(str => str.Length);
        return strings.Where(s => s.Length == minSize);
    }
