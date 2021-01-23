    return Observable.Create<T>(observer => 
    {
      var subject = new Subject<Unit>();
      var disposable = new CompositeDisposable(subject);
    
      disposable.Add(subject
        //This will complete when provider has run out of values
        .TakeWhile(_ => _provider.HasNext)
        .SelectMany(
          _ => _provider.GetNextAsync(),
         (_, item) => 
         {
           return _processors
            .Aggregate(
             seed: Observable.Return(item),
             func: (current, processor) => current.SelectMany(processor.ProcessAsync))
            //Could also use `Finally` here, this signals the chain
            //to start on the next item.
            .Do(dontCare => {}, () => subject.OnNext(Unit.Default));
         }
        )
        .Merge(3)
        .Subscribe(observer));
    
      //Queue up 3 requests for the initial kickoff
      disposable.Add(Observable.Repeat(Unit.Default, 3).Subscribe(subject.OnNext));
    
      return disposable;
    });
