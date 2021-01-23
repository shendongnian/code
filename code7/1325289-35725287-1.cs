    static async Task<Dictionary<string,string>> GetUrls(string[] urls)
    {
        var tasks = urls.Select(async url =>
        {
            using (var client = new WebClient())
            {
                return new { url, content = await client.DownloadStringTaskAsync(url) };
            };
        }).ToList();
        var results = await Task.WhenAll(tasks);
        return results.ToDictionary(pair => pair.url, pair => pair.content);
    }
