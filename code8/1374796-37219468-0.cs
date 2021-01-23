    private static ConcurrentDictionary<Guid, ConcurrentQueue<string>> _progressInfo;
    //You should never do "async void" WCF can handle using tasks and having Async suffixes.
    //see https://blogs.msdn.microsoft.com/endpoint/2010/11/12/simplified-asynchronous-programming-model-in-wcf-with-asyncawait/
    public async Task BeginSyncAsync(string dbId, Guid progressKey)
    {
        if (!_progressInfo.TryAdd(progressKey, new ConcurrentQueue<string>()))
        {
            throw new InvalidOperationException("progress key is in use");
        }
        var progressIndicator = new Progress<string>((value) => ReportSyncProgress(value, progressKey));
        try
        {
            var output = await BeginSyncTaskAsync(dbId, progressIndicator);
        }
        finally
        {
            //Remove progress list
            ConcurrentQueue<string> temp;
            _progressInfo.TryRemove(progressKey, out temp);
        }
    }
    public List<string> GetSyncProgress(Guid progressKey)
    {
        ConcurrentQueue<string> progressOutput;
        if (!_progressInfo.TryGetValue(progressKey, out progressOutput))
        {
            //the key did not exist, retun null;
            return null;
        }
            
        //transform the queue to a list and return it.
        return progressOutput.ToList();
    }
    private void ReportSyncProgress(string value, Guid progressKey)
    {
        ConcurrentQueue<string> progressOutput;
        if (!_progressInfo.TryGetValue(progressKey, out progressOutput))
        {
            //the key did not exist, progress is being reported for a completed item... odd.
            return;
        }
        //This is the requests specific queue of output.
        progressOutput.Enqueue(value);
    }
