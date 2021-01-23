    var pollingPeriod = TimeSpan.FromSeconds(n);
    var scheduler = new EventLoopScheduler(ts => new Thread(ts) {Name = "DestinationPoller"});
    var query = Observable.Timer(pollingPeriod , scheduler)
        .SelectMany(_ => destinationRepository.GetDestination().ToObservable())
        .TakeWhile(response => response.HasDestination)
        .Retry()    //Loop on errors
        .Repeat()  //Loop on success
        .Select(response => response.Destination)
        .Take(1);
