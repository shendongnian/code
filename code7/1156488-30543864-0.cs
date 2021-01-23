    public Task<int> ExternalActionAsync(CancellationToken? token = null)
    {
        if (token == null)
        {
            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter((int)_timeout.TotalMilliseconds);
            token = tokenSource.Token;
        }
    
        return InternalActionAsync(token);
    }
