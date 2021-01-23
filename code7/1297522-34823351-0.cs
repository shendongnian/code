    public static TSource MinByOrDefault<TSource, TKey>(this IEnumerable<TSource> source,
        Func<TSource, TKey> selector)
    {
        return source.MinByOrDefault(selector, Comparer<TKey>.Default);
    }
    public static TSource MinByOrDefault<TSource, TKey>(this IEnumerable<TSource> source,
        Func<TSource, TKey> selector, IComparer<TKey> comparer)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (selector == null) throw new ArgumentNullException("selector");
        if (comparer == null) throw new ArgumentNullException("comparer");
        using (var sourceIterator = source.GetEnumerator())
        {
            if (!sourceIterator.MoveNext())
            {
                return default(TSource); //This is the only line changed.
            }
            var min = sourceIterator.Current;
            var minKey = selector(min);
            while (sourceIterator.MoveNext())
            {
                var candidate = sourceIterator.Current;
                var candidateProjected = selector(candidate);
                if (comparer.Compare(candidateProjected, minKey) < 0)
                {
                    min = candidate;
                    minKey = candidateProjected;
                }
            }
            return min;
        }
    }
