    public Task<byte[]> Download(DocumentProfile profile)
    {
        var tcs = new TaskCompletionSource<byte[]>();
        service.DownloadLastVersionCompleted += OnDownloadCompleted;
        service.DownloadLastVersionAsync(profile, state: tcs);
        return tcs.Task;
    }
    private void OnDownloadCompleted(
        object sender, DownloadLastVersionCompletedEventArgs args)
    {
        var tcs = (TaskCompletionSource<byte[]>)args.State;
        if (args.Error != null)
            tcs.TrySetResult(null);
        if (args.Result != null)
            tcs.TrySetResult(args.Result);
        else
            tcs.TrySetResult(new byte[0]);
    }
