    public Task<string> RequestAsync(string url)
    {
        var httpClient = new HttpClient();
        return httpClient.GetAsStringAsync(url);
    }
