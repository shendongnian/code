    public static IDisposable SchedulePeriodic(
        this IScheduler scheduler,
        TimeSpan interval,
        Action<CancellationToken> work) {
        if (scheduler == null) {
            throw new ArgumentNullException("scheduler");
        }
        if (work == null) {
            throw new ArgumentNullException("work");
        }
        var cancellationDisposable = new CancellationDisposable();
        var subscription = scheduler.SchedulePeriodic(
            interval,
            () => {
                try {
                    work(cancellationDisposable.Token);
                } catch (OperationCanceledException e) {
                    if (e.CancellationToken != cancellationDisposable.Token) {
                        // Not the token we passed in
                        throw;
                    }
                }
            });
        return new CompositeDisposable(cancellationDisposable, subscription);
    }
