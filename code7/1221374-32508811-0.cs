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
        foreach (var value in getAvailableValuesForKey(firstKey))
        {
            foreach (var dictionary in EnumerateAllPossibleCombinations(keys.Skip(1), getAvailableValuesForKey))
            {
                dictionary.Add(firstKey, value);
                yield return dictionary;
            }
        }
    }
