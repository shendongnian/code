    private async Task<object> GetRequest(string url)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.twitchtv.v3+json"));
    
        var response = await httpClient.GetAsync(url);
        var contents = await response.Content.ReadAsStringAsync();
        
        return contents;
    }
