    public static IEnumerable<IObservable<T>> ObserveElements<T>(this IObservable<IEnumerable<T>> obs)
    {
        var sub = new Subject<IEnumerable<T>>();
        obs.Subscribe(sub);
        var i = 0;
        while (true)
        {
            var idx = i++;
            yield return from enumerable in sub
                         let x = enumerable.ElementAtOrDefault(idx)
                         where !Equals(x, default(T))
                         select x;
        }
    }
