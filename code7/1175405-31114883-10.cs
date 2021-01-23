    public async Task<string> GetArrayAsync()
    {
        HttpClient client = new HttpClient();
        var responseStream = await client.GetStreamAsync("http://msdn.microsoft.com");
        using (var streamReader = new StreamReader(responseStream))
        {
            return await streamReader.ReadToEndAsync();
        }
    }
