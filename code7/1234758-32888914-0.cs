    public async Task<HttpResponseMessage> PostAsync(Uri uri, StringContent content)
    {
        var task = await _httpClient.PostAsync(uri, content);
        var result = await task;
        return result;
    }
