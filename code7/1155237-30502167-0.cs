    public Task<byte[]> Download(DocumentProfile profile)
    {
        var state = new DownloadState();
        
        service.DownloadLastVersionCompleted += state.OnDownloadCompleted;
        service.DownloadLastVersionAsync(profile);
        return state.Task;
    }
    class DownloadState
    {
        private TaskCompletionSource<byte[]> tcs = new TaskCompletionSource<byte[]>();
        public Task<byte[]> Task {  get { return tcs.Task; } }
        public void OnDownloadCompleted(
             object sender, DownloadLastVersionCompletedEventArgs args)
        {
            if (args.Error != null)
                tcs.TrySetResult(null);
            if (args.Result != null)
                tcs.TrySetResult(args.Result);
            else
                tcs.TrySetResult(new byte[0]);
        }
    }
