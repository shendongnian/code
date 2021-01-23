    public static IEnumerable<IEnumerable<T>> GroupWhile<T>(this IEnumerable<T> source, Func<T, T, bool> func)
    {
        var firstElement = source.FirstOrDefault();
    
        return firstElement == null ? Enumerable.Empty<IEnumerable<T>>() : source.Skip(1).Aggregate(new
        {
            current = Tuple.Create(firstElement, ImmutableList<T>.Empty.Add(firstElement)),
            results = ImmutableList<ImmutableList<T>>.Empty,
        }, (acc, x) =>
            func(acc.current.Item1, x)
            ? new { current = Tuple.Create(x, acc.current.Item2.Add(x)), results = acc.results }
            : new { current = Tuple.Create(x, ImmutableList<T>.Empty.Add(x)), results = acc.results.Add(acc.current.Item2) }, 
            x => x.results.Add(x.current.Item2).Select(r => r));
    }
