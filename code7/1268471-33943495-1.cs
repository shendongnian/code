    // This is just an example
    public async Task<string> Post(string url, string safeUrl)
    {
         HttpResponseMessage response = await httpClient.PostAsync(url, null);
         string content = await response.Content.ReadAsStringAsync();
         return content;
    }
