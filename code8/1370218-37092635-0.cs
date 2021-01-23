    var numbers = Enumerable.Range(1, 10).ToObservable();
    var processed = numbers.SelectMany(n => 
      //Defer call passed method every time it is subscribed to,
      //Allowing the Retry to work correctly.
      Observable.Defer(() => 
        Process(n).ToObservable()).Retry()
    );
    processed.Subscribe( f => Console.WriteLine(f));
