    using (var client = new HttpClient())
    {
        var cts = new CancellationTokenSource()
        var responseTask = client.GetAsync(urlToInvoke, cts.Token);
        Task.Delay(5000).Wait()
        cts.Cancel();
    }
