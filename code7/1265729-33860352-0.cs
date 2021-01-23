    public Task DownloadPackagesAsync()
    {
        _downloadCancellationTokenSource.Dispose();
        _downloadCancellationTokenSource = new CancellationTokenSource();
        return Task.Factory.StartNew(DownloadPackages).ContinueWith(DownloadTaskCompleted,
            _downloadCancellationTokenSource.Token,
            TaskContinuationOptions.None,
            TaskScheduler.Default);
    }
