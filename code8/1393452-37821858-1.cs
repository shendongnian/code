    public async Task InvokeRequest()
    {
        using (var cts = new CancellationTokenSource(System.TimeSpan.FromMinutes(3)))
        {
             await myHandler.SendAsync(new HttpRequestMessage { ... }, cts.Token).ConfigureAwait(false);
        }        
    }
