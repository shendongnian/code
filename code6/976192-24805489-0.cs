    public static IObservable<T> HotConcat<T>(params IObservable<T>[] sources)
    {
        var s2 = sources.Select(s => s.BufferUntilSubscribed());
        var subscriptions = new CompositeDisposable(s2.Select(s2 => s2.Connect()).ToArray());
        return Observable.Create<T>(observer =>
        {
            var s = new SingleAssignmentDisposable();
            var d = new CompositeDisposable(subscriptions);
            d.Add(s);
            s.Disposable = s2.Concat().Subscribe(observer);
            return d;
        });
    }
