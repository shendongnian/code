    public void Stop(string userId)
    {
        CancellationTokenSource tokenSource;
        if(dictionary.TryGetValue(userId, out tokenSource))
        {
            tokenSource.Cancel();
            dictionary.TryRemove(userId out tokenSource);
        }
    }
