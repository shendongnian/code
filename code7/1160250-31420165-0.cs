    public static IObservable<RecoveryOptionResult> GetResultAsync(this UserError This, RecoveryOptionResult defaultResult = RecoveryOptionResult.CancelOperation)
    {
        return This.RecoveryOptions.Any() ?
            This.RecoveryOptions
                .Select(x => x.IsExecuting
                    .Skip(1) // we can skip the first event because it's just the initial state
                    .Where(_ => x.RecoveryResult.HasValue) // only stream results that have a value
                    .Select(_ => x.RecoveryResult.Value)) // project out the result value
                .Merge() // merge the list of command events into a single event stream
                .FirstAsync() : //only consume the first event
            Observable.Return(defaultResult);
    }
