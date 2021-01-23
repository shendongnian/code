    static async Task<Dictionary<string, string>> GetUrls(string[] urls)
    {
        var urlsAndData = urls
            .Distinct()
            .Select(DownloadStringAsync)
            .Zip(urls, async (data, url) => new { url, data = await data });
        return (await Task.WhenAll(urlsAndData)).ToDictionary(a => a.url, a => a.data);
    }
    private static async Task<string> DownloadStringAsync(string url)
    {
        using (var client = new WebClient())
        {
            return await client.DownloadStringTaskAsync(url);
        }
    }
