    public static List<List<object>> Split(List<object> source)
    {
        return source
            .Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / 10)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }
