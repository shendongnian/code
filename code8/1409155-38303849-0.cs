    private static ConcurrentDictionary<string, Task<string>> s_urlToContents;
    
    public static Task<string> GetContentsAsync(string url)
    {
        Task<string> contents;
        if(!s_urlToContents.TryGetValue(url, out contents))
        {
            contents = GetContentsAsync(url);
            contents.ContinueWith(t => s_urlToContents.TryAdd(url, t); },
            TaskContinuationOptions.OnlyOnRanToCompletion |
            TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
        }
        return contents;
    }
    
    private static async Task<string> GetContentsAsync(string url)
    {
        var response = await new HttpClient().GetAsync(url);
        return response.EnsureSuccessStatusCode().Content.ReadAsString();
    }
