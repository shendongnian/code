    public static IObservable<T> Regulate<T>(this IObservable<T> source, TimeSpan period)
    {
        var interval = Observable.Interval(period).Publish().RefCount();
    
        return source.Select(x => Observable.Return(x)
                                            .CombineLatest(interval, (v, _) => v)
                                            .Take(1))
                     .Concat();
    }
