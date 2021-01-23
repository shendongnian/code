    if (t.IsFaulted || t.IsCanceled)
    {
        // Login failed
        cts.Cancel();
        cts.Token.ThrowIfCancellationRequested();
    }
