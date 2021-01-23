    async Task<Dictionary<string, byte[]>> ReturnFileDataAsync(IEnumerable<string> urls)
    {
      Dictionary<string, Task<byte[]>> dictionary;
      using (var client = new HttpClient())
      {
        dictionary = urls.ToDictionary(uri => uri, client.GetByteArrayAsync);
        await Task.WhenAll(dictionary.Values);
      }
      return dictionary.ToDictionary(pair => Path.GetFileName(pair.Key), pair => pair.Value.Result);
    }
