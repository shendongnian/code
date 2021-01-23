    public static IObservable<IEnumerable<TSource>> Limit<TSource>(
        this IObservable<TSource> source,
        int count,
        TimeSpan timeSpan,
        IScheduler scheduler)
    {
        return Observable.Create<IEnumerable<TSource>>(
            observer =>
                {
                    var buffer = new Queue<TSource>();
    
                    var guard = new object();
    
                    var sourceSub = source
                        .Subscribe(x =>
                                {
                                    lock (guard)
                                    {
                                        buffer.Enqueue(x);
                                    }
                                }, 
                            observer.OnError, 
                            observer.OnCompleted);
    
                    var timer = Observable.Interval(timeSpan, scheduler)
                        .Subscribe(_ =>
                            {
                                lock (guard)
                                {
                                    var batch = new List<TSource>();
                                    while (batch.Count <= count && buffer.Any())
                                    {
                                        batch.Add(buffer.Dequeue());
                                    }
    
                                    observer.OnNext(batch.AsEnumerable());
                                }
                            });
    
                    return new CompositeDisposable(sourceSub, timer);
                });
    }
