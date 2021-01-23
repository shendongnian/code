    private Task<FileMeta[]> ReturnFileDataAsync(IEnumerable<string> urls)
    {
        var client = new HttpClient();
        return Task.WhenAll(urls.Select(async url => new FileMeta
        {
            FileName = Path.GetFileName(url),
            FileData = await client.GetByteArrayAsync(url),
        }));
    }
