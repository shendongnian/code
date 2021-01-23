    public static IObservable<bool> Foo(
        this IEnumerable<IObservable<bool>> sources)
    {                       
        var sourceArray = sources.Select(s => s.Publish().RefCount()).ToArray();   
           
        var terminal = sourceArray.ToObservable()
            .SelectMany(x => x.LastAsync().Where(y => y == false)).FirstAsync();
          
        var combined = sourceArray
            .CombineLatest(values => values.All(x => x))
            .DistinctUntilChanged();            
            
        return terminal.Publish(t =>
            combined.TakeUntil(t));
    }  
