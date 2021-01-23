    public TransactionProcessor(int? debugForcedCancellationDelay = null)
    {
        // ...
        Task = RepeatActionEvery(
            () => TestingLog.Add("Repeat Action Every 1 Second"), 
            TimeSpan.FromSeconds(1), 
            _cancellationToken.Token);
    }
    
    public async Task CancelProcessingAsync()
    {
        _cancellationToken.Cancel();
        await Task;
    }
