    public static async Task<Stream> GetFileContent(string strFileId)
    {
        var file = (IFileFetcher)(await _spFilesClient.Files.GetById(strFileId).ToFile().ExecuteAsync());
     
        var streamFileContent = await file.DownloadAsync();
     
        streamFileContent.Seek(0, System.IO.SeekOrigin.Begin);
     
        return streamFileContent;
    }
