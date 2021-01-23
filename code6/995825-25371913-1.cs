    static async Task<Dictionary<string, byte[]>> ReturnedFileData(IEnumerable<string> urlList)
    {
        var dictionary = new Dictionary<Uri, Task<byte[]>>();
        using (var client = new WebClient())
        {
            foreach (var url in urlList)
            {
                var uri = new Uri(url);
                dictionary[uri] = client.DownloadDataTaskAsync(uri);
            }
            await Task.WhenAll(dictionary.Values);
        }
        return dictionary.ToDictionary(pair => Path.GetFileName(pair.Key.LocalPath), pair => pair.Value.Result);
    }
