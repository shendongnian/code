    public static IObservable<T> Pausable<T>(this IObservable<T> source, IObservable<bool> pauser)
    {
        return Observable.Create<T>(obs => {
            var queue = source.Buffer(pauser.Where(toPause => !toPause),
                                      _ => pauser.Where(toPause => toPause))
                              .SelectMany(l => l.ToObservable());
    
            return source.Window(pauser.Where(toPause => toPause).StartWith(true), 
                                 _ => pauser.Where(toPause => !toPause))
                         .Switch()
                         .Merge(queue)
                         .Subscribe(obs);
        });
    }
