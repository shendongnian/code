    public static IEnumerable<T> GetItemsWhichOccurAtLeastIn<T>(this IEnumerable<IEnumerable<T>> seq, int minCount, IEqualityComparer<T> comparer = null)
    {
        if (comparer == null) comparer = EqualityComparer<T>.Default;
        Dictionary<T, int> itemCounts = new Dictionary<T, int>(comparer);
        foreach (IEnumerable<T> subSeq in seq)
        {
            foreach (T x in subSeq.Distinct(comparer))
            {
                if (itemCounts.ContainsKey(x))
                    itemCounts[x] += 1;
                else
                    itemCounts.Add(x, 1);
            }
        }
        foreach(var kv in itemCounts.Where(kv => kv.Value >= minCount))
            yield return kv.Key;
    }
