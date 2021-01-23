    public static IObservable<bool> Foo(
        this IEnumerable<IObservable<bool>> sources)
    {
        var projectedSources = sources.Select(source => source
            .Materialize()
            .Scan(
                new
                {
                    Latest = true,
                    IsCompleted = false
                },
                (tuple, notification) => new
                {
                    Latest = notification.HasValue ? notification.Value : e.Latest,
                    IsCompleted = tuple.IsCompleted || !notification.HasValue
                }));
        return projectedSources
            .CombineLatest()
            .TakeWhile(list => list.All(x => !x.IsCompleted || x.Latest))
            .Select(list => list.All(x => x.Latest))
            .DistinctUntilChanged();
    }
