    var flush = new Subject<Unit>();
    var source = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(_ => Unit.Default).Publish().RefCount();
    var closer = CloseGenerator(source, flush, 5);
    source.Buffer(closer)
    //...
    private IObservable<Unit> CloseGenerator<T>(IObservable<T> source, 
                                                 IObservable<Unit> flusher, int count)
    {
         return Observable.CombineLatest(
                            source.Select((_, i) => i), 
                            flusher.Select((_, i) => i).StartWith(-1))
                 .Select(ar => Tuple.Create(ar[0], ar[1]))
                 .Scan(Tuple.Create(-1, -1), (prev, next) =>
                     {
                         if(next.Item2 != prev.Item2 || next.Item1 == prev.Item1 + count)
                             return next;
                         else
                             return prev;
                     }
                 )
                 .DistinctUntilChanged().Skip(1) //This is 'DistinctExceptFirst'
                 .Select(_ => Unit.Default);
    }
