     `public void OnTimeout(IAsyncResult ar)
     {
        tokenSource.Cancel();
        tokenSource.Token.ThrowIfCancellationRequested();
     }`
