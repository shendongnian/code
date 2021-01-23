    public Task TapAsync(int x, int y, int timeouttime)
    {
        CancellationTokenSource cts;
        cts = new CancellationTokenSource();
        cts.CancelAfter(timeouttime);
        return TapAsync(x, y, source.Token);
    }
    
    public async Task TapAsync(int x, int y, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        await myWriter.WriteLineAsync("input tap " + x.ToString() + " " + y.ToString());
        token.ThrowIfCancellationRequested();
        await myWriter.FlushAsync();
        token.ThrowIfCancellationRequested();
        await Task.Delay(2000, token);
    }
