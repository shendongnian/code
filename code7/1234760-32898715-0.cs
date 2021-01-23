    public async Task<HttpResponseMessage> PostAsync(Uri uri, StringContent content)
    {
        var cancellation = new CancellationTokenSource(5000); // Cancel after 5 seconds.
        return await _httpClient.PostAsync(uri, content, cancellation.Token);
    }
