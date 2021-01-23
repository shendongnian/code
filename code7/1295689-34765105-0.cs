    Task<IConnection> connectionTask = Observable.Start(() => Factory.GetObject(typeof (IConnection)), Scheduler.Default).Timeout(TimeSpan.FromSeconds(20)).ToTask());
    using (var connection = connectionTask.Result)
    {
        ...
    }
