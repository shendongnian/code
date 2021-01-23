    var observable = Observable.Merge<IntEventArgs>(h => _eventSource.Happened += h, h => _eventSource.Happened -= h)
                               .Publish()
                               .RefCount();
    var seq = Observable.Merge<IntEventArgs>(observable.FirstAsync(),
                                             observable.Skip(1).Sample(sampler));
