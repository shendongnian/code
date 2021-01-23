    async Task<Dictionary<string, byte[]>> ReturnFileDataAsync(IEnumerable<string> urls)
    {
      using (var client = new HttpClient())
      {
        var results = await Task.WhenAll(urls.Select(async url => new
        {
          Key = Path.GetFileName(url), 
          Value = await client.GetByteArrayAsync(url),
        }));
        return results.ToDictionary(x => x.Key, x => x.Value);
      }
    }
