    public static IEnumerable<IDictionary<TKey, TSource>> EnumerateAllPossibleCombinations<TKey, TSource>(
        IEnumerable<TKey> keys,
        Func<TKey, IEnumerable<TSource>> getAvailableValuesForKey)
    {
        if (!keys.Any())
        {
            yield return new Dictionary<TKey, TSource>();
            yield break;
        }
        var firstKey = keys.First();
        var values = getAvailableValuesForKey(firstKey);
        bool hasValues = values.Any();
        foreach (var value in values.DefaultIfEmpty())
        {
            foreach (var dictionary in EnumerateAllPossibleCombinations(keys.Skip(1), getAvailableValuesForKey))
            {
                if (hasValues)
                {
                    dictionary.Add(firstKey, value);
                }
                yield return dictionary;
            }
        }
    }
