    async Task<Dictionary<string, byte[]>> ReturnFileData(IEnumerable<string> urls)
    {
        var dictionary = urls.Select(url => new Uri(url)).ToDictionary(
            uri => uri,
            uri => new WebClient().DownloadDataTaskAsync(uri));
        await Task.WhenAll(dictionary.Values);
        return dictionary.ToDictionary(
            pair => Path.GetFileName(pair.Key.LocalPath),
            pair => pair.Value.Result);
    }
