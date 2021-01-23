    var cts = new CancellationTokenSource();
    var observable = GetAllData(new[] { "1", "2", "3" }).ToObservable().TakeWhile(x => !cts.IsCancellationRequested);
    var subs = observable
        .SubscribeOn(Scheduler.Default)
        .Subscribe(
            data => Console.WriteLine(data.Id), 
            () => Console.WriteLine("All Data Fetched Completed"));
    //...
    cts.Cancel();
