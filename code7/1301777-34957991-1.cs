    public static void RateLimitedForEach<T>
    (
        this List<T> list,
        double minumumDelay,
        Action<T> action
    )
    {
        using (var waitHandle = new ManualResetEventSlim(false))
        {
            var mainObservable = list.ToObservable();
            var intervalObservable = Observable.Interval(TimeSpan.FromSeconds(minumumDelay));  
            var zipObservable = mainObservable .Zip(intervalObservable, (v, _) => v);
            zipObservable.Subscribe
            (
                action,
                error => GC.KeepAlive(error), // Ingoring them, as you already were
                () => waitHandle.Set() // <-- "Done signal"
            );
    
            waitHandle.Wait(); // <--- Waiting on the observer to complete
        }
    }
