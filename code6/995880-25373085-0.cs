    async Task<Dictionary<string, byte[]>> ReturnFileData(IEnumerable<string> urls)
    {
        Dictionary<Uri, Task<byte[]>> dictionary = urls
            .Select(url => new Uri(url))
            .ToDictionary(uri => uri, GetTheDataAsync);
        await Task.WhenAll(dictionary.Values);
        return dictionary
            .ToDictionary(
                pair => Path.GetFileName(pair.Key.ToString()),
                pair => pair.Value.Result);
    }
    async Task<byte[]> GetTheDataAsync(Uri uri)
    {
        using (var client = new WebClient())
        {
            return await client.DownloadDataTaskAsync(uri);
        }
    }
   
