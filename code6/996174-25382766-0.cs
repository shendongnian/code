    public IAsyncOperation<bool> WaitOneAsync()
    {
        return AsyncInfo.Run<bool>(async cancellationToken =>
            {
                while (!_semaphore.WaitOne(0))
                {
                    Logger.Log("Waiting...");
                    await Task.Delay(100, cancellationToken);
                }
                return true;
            });
    }
