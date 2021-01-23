    async Task<Dictionary<string, byte[]>> ReturnFileData(IEnumerable<string> urls)
    {
        var dictionary = urls.ToDictionary(
            url => new Uri(url),
            url => new WebClient().DownloadDataTaskAsync(url));
        await Task.WhenAll(dictionary.Values);
        return dictionary.ToDictionary(
            pair => Path.GetFileName(pair.Key.LocalPath),
            pair => pair.Value.Result);
    }
