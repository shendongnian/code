    public static IEnumerable<List<object>> PartitionByTypes(List<object> values)
    {
        Type prevType = null;
        List<object> cache = new List<object>();
        foreach (var value in values)
        {
            if(prevType != null && value.GetType() != prevType)
            {
                yield return cache;
                cache = new List<object>();
            }
            cache.Add(value);
            prevType = value.GetType();
        }
        if(cache.Count > 0)
            yield cache;
    }
