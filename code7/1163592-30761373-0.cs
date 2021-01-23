    public IObservable<T> ThrottleOrMax<T>(this IObservable<T> source, TimeSpan throttleTime, TimeSpan maxWaitTime)
    {
        return source
            .GroupByUntil(
                t => 0, // they all get the same key
                t => t, // the element is the element
                g =>
                {
                    // expire the group when it slows down for throttleTime
                    // or when it exceeds maxWaitTime
                    return g
                        .Throttle(throttleTime)
                        .Timeout(maxWaitTime, Rx.Observable.Empty<T>());
                })
            .SelectMany(g => g.LastAsync());
    }
