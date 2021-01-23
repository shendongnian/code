    public static IObservable<bool> Foo(
        this IEnumerable<IObservable<bool>> sources)
    {                       
        var sourceArray = sources.Select(s => s.Publish().RefCount()).ToArray();
           
        var terminator = sourceArray.ToObservable()
            .SelectMany(x => x.LastAsync().Where(y => y == false));
          
        return sourceArray
            .CombineLatest(values => values.All(x => x))
            .DistinctUntilChanged()
            .TakeUntil(terminal);
    }  
