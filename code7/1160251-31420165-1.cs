    public static IObservable<RecoveryOptionResult> GetResultAsync(this UserError This, RecoveryOptionResult defaultResult = RecoveryOptionResult.CancelOperation)
    {
        return This.RecoveryOptions.Any() ?
            This.RecoveryOptions
                .Cast<RecoveryCommand>()
                .Select(x => x // our command is now observable
                    // we don't Skip(1) here because we're not observing a property any more
                    .Where(_ => x.RecoveryResult.HasValue)
                    .Select(_ => x.RecoveryResult.Value))
                .Merge()
                .FirstAsync() :
            Observable.Return(defaultResult);
    }
