    private IObservable<Destination> CreateOrderDestinationObservable(string boxId, int orderId)
    {
        var pollingPeriod = TimeSpan.FromSeconds(DestinationPollingDelay);
        var scheduler = new EventLoopScheduler(ts => new Thread(ts) {Name = "DestinationPoller"});
    
        var observable = Observable.Interval(pollingPeriod, scheduler)
            .SelectMany(_ => externalBridgeRepository.GetDestination(boxId, orderId).ToObservable())
            .Where(response => response.HasDestination)
            .Retry()
            .Repeat()
            .Take(1)
            .Select(response => response.Destination);
    
        return observable;
    }
