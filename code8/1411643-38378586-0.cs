    CancellationTokenSource cts = new CancellationTokeSource();
    List<Task> tasks = new List<Task>
    {
        Task.Run(()= > srvCtl.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 30)), cts),
        Task.Run(()= > srvCtl.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 30)), cts),
        ...
    }
    // When any of the tasks completes, it means the service reached on of the statuses you were tracking
    await Task.WhenAny(tasks);
    // To cancel the rest of the tasks that are still waiting
    cts.Cancel();
