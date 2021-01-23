    // timer that completes after 1 second
    var intervalTimer = Observable
        .Empty<string>()
        .Delay(TimeSpan.FromSeconds(1));
    // queries one time whenever subscribed
    var query = Observable.FromAsync(GetCurrentDate);
    // query + interval timer which completes
    // only after both the query and the timer
    // have expired
    var intervalQuery = Observable.Merge(query, intervalTimer);
    // Re-issue the query whenever intervalQuery completes
    var queryLoop = intervalQuery.Repeat();
    // Keep the 20 most recent results
    // Note.  Use an immutable list for this
    // https://www.nuget.org/packages/microsoft.bcl.immutable
    // otherwise you will have problems with
    // the list changing while an observer
    // is still observing it.
    var recentResults = queryLoop.Scan(
        ImmutableList.Create<string>(), // starts off empty
        (acc, item) =>
        {
            acc = acc.Add(item);
            if (acc.Count > 20)
            {
                acc = acc.RemoveAt(0);
            }
            return acc;
        });
    // store the results
    recentResults
        .ObserveOnDispatcher()
        .Subscribe(items =>
        {
            this.CurrentTime = items[0];
            this.RecentItems = items;
        });
