    async Task<Dictionary<string, byte[]>> ReturnFileData(IEnumerable<string> urls)
    {
        Dictionary<Uri, Task<byte[]>> dictionary;
        using (var client = new WebClient())
        {
            dictionary = urls.Select(url => new Uri(url)).ToDictionary(
                uri => uri,
                uri => client.DownloadDataTaskAsync(uri));
            await Task.WhenAll(dictionary.Values);
        }
        return dictionary.ToDictionary(
            pair => Path.GetFileName(pair.Key.LocalPath),
            pair => pair.Value.Result);
    }
