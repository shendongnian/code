    public static List<T> FindCommon<T>(List<List<T>> lists)
    {
        return lists
            .SelectMany(x => x)
            .Distinct()
            .Where(item => lists.All(l => l.Contains(item)))
            .ToList();
    }
