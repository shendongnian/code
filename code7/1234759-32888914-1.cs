    public async Task<HttpResponseMessage> PostAsync(Uri uri, StringContent content)
    {
        var cancellation = new CancellationTokenSource();
        var task = _httpClient.PostAsync(uri, content, cancellation.Token);
        var timeout = Task.Delay(5000);
        await Task.WhenAny(task, timeout);
        if(timeout.IsCompleted)
        {
            cancellation.Cancel();
            throw new TimeoutException();
        }
        else
            return await task;
    }
