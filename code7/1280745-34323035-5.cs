    public static IObservable<bool> Foo(
        this IEnumerable<IObservable<bool>> sources)
    {                       
        var sourceArray = sources.Select(s => s.Publish().RefCount()).ToArray();
    
        var terminator = sourceArray
            .ToObservable(Scheduler.Default)
            .SelectMany(x => x.StartWith(true).LastAsync().Where(y => y == false));
    
        var result = sourceArray
            .CombineLatest(values => values.All(x => x))
            .DistinctUntilChanged()
            .TakeUntil(terminator);
        
        return result; 
    }  
