    public void Start()
    {
        _cancellationToken = new CancellationTokenSource();
        var token = _cancellationToken.Token;
        _pollingTask = Task.Factory.StartNew(
            () =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        Log.Debug("Call Import PDF");
                        ConnectUncPaths();
                        ImportPdf();
                        Task.Delay(TimeSpan.FromMinutes(Intervall), token)
                    }
                    catch (Exception)
                    {
                        DissconnectUncPaths();
                        break;
                    }
                }
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Current);
    }
