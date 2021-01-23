    // Assuming this is _decoratedPolicy.ExecuteAsync
    public async Task ExecuteAsync(Action action, CancellationToken token)
    {
         // This is what creates and throws the OperationCanceledException
         token.ThrowIfCancellationRequested();
    
         // Simulate some work
         await Task.Delay(20);
    }
