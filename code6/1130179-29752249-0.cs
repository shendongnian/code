    var published = Observable
       .Interval(...)
       .Select(...)
       .Publish();
    var connectionSubscription = published.Connect();
    var observerSubscription = published.Subscribe(...);
