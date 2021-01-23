    protected override void OnStart()
    {
        var token = _cancellationTokenSource.Token;
        _tasks.Add(RunTask1(token));
        _tasks.Add(RunTask2(token));
        _tasks.Add(Task.Run(() => RunTask3(token))); // assuming RunTask3 has a long synchronous part
    }
    
    List<Task> _tasks;
    
    protected override void OnStop()
    {
        _cancellationTokenSource.Cancel();
        Task.WhenAll(_tasks).Wait();
    }
