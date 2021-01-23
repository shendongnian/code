    public string DownloadFile(string fileName, string fileType)
    {
        var handlingDownloader = _downloaders
            .FirstOrDefault(d => d.FileType == fileType);
        if (handlingDownloader == null) 
        {
            // Probably throw an Exception
        }
        return handlingDownloader.Download(fileName);
    }
