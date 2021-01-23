    public static List<T> FindCommon<T>(List<List<T>> lists)
    {
        return lists.GroupBy(x => x, new ListEqualityComparer<T>())
            .OrderByDescending(g => g.Count())
            .Select(x => x.Key)
            .FirstOrDefault();
    }
