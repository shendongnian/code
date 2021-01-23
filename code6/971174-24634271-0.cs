    public static IEnumerable<IEnumerable<T>> GroupWhileAggregating<T, TAccume>(
        this IEnumerable<T> source,
        TAccume seed,
        Func<TAccume, T, TAccume> accumulator,
        Func<TAccume, T, bool> predicate)
    {
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
                yield break;
            List<T> list = new List<T>() { iterator.Current };
            TAccume accume = accumulator(seed, iterator.Current);
            while (iterator.MoveNext())
            {
                accume = accumulator(accume, iterator.Current);
                if (predicate(accume, iterator.Current))
                {
                    list.Add(iterator.Current);
                }
                else
                {
                    yield return list;
                    list = new List<T>() { iterator.Current };
                    accume = accumulator(seed, iterator.Current);
                }
            }
            yield return list;
        }
    }
