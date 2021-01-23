    public string GetLongestString(params string[] strings)
    {
        return strings.OrderBy(s => s.Length).First();
    }
    public string GetShortestString(params string[] strings)
    {
        return strings.OrderByDescending(s => s.Length).First();
    }
