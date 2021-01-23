    public async Task<bool> downloadSimpleFile(string fileUrl)
    {
        //download file logic
        return true;
    }
    public async Task ProcessList()
    {
        var list = new List<string> {"url1", "url2", "url3" };
        var downloadFiles = list.Select(downloadSimpleFile).ToArray();
        var result = await Task.WhenAll(downloadFiles);
    }
