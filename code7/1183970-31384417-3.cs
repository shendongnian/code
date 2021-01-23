    public static IEnumerable<T> GetItemsWhichOccurAtLeastIn<T>(this IList<IEnumerable<T>> seq, int minCount, IEqualityComparer<T> comparer = null)
    {
        if (comparer == null) comparer = EqualityComparer<T>.Default;
        Dictionary<T, int> itemCounts = new Dictionary<T, int>(comparer);
        for (int i = 0; i < seq.Count; i++)
        {
            IEnumerable<T> subSeq = seq[i];
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
