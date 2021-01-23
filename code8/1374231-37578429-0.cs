    // signal to indicate we want more events to flow
    var signal = new BehaviorSubject<bool>(true);
    var source = Observable.Interval(TimeSpan.FromMilliseconds(100)).Take(27).Publish();
    // Observable to the source but have it skip the last value (would have published the same value twice if not doing this. Ex: if take was 33 instead of 27)
    var sequence = source.SkipLast(1).Publish();
    // Observable that is just the lastvalue in the sequence
    var last = source.PublishLast();
    var d = signal.DistinctUntilChanged()
        .Where(on => on) // only let go if we have signal set to true
        .SelectMany(last.Do(_ => signal.OnCompleted()).Merge(sequence).Take(1))  // Side effect of last is to turn off signal
        .Subscribe(
            async ps =>
            {
                signal.OnNext(false); // no more values from the source
                await LengthyWork(ps);
                signal.OnNext(true); // resubscribe to the source
            });
    // wire it all  up
    last.Connect();
    sequence.Connect();
    source.Connect();
    Thread.Sleep(5000);
    Console.WriteLine("Stopping");
    d.Dispose();
