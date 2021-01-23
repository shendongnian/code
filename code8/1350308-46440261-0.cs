    /// <summary>
    /// Start a download and wait for a file to appear
    /// https://stackoverflow.com/a/46440261/1141876
    /// </summary>
    /// <param name="expectedExtension">If we don't know the extension, Chrome creates a temp file in download folder and we think we have the file already</param>
    protected List<FileInfo> ActAndWaitForFileDownload(
        Action action
        , string expectedExtension
        , TimeSpan maximumWaitTime)
    {
        Directory.CreateDirectory(DownloadDirectory);
        var fileCountbefore = Directory.GetFiles(DownloadDirectory).Length;
        var stopwatch = Stopwatch.StartNew();
    
        action();
    
        var isTimedOut = false;
        var extensionFilter = $"*{expectedExtension}";
    
        Func<bool> fileAppearedOrTimedOut = () =>
        {
            isTimedOut = stopwatch.Elapsed > maximumWaitTime;
            var isFilePresent = Directory
                                    .GetFiles(DownloadDirectory, extensionFilter)
                                    .Length == fileCountbefore;
    
            return isFilePresent && !isTimedOut;
        };
    
        do
        {
            Thread.Sleep(500);
            Log($"Waited {stopwatch.Elapsed} (max={maximumWaitTime}) for download '{extensionFilter}'...");
        }
        while (fileAppearedOrTimedOut());
    
        var files = Directory
                        .GetFiles(DownloadDirectory)
                        .Select(s => new FileInfo(s))
                        .ToList();
        
        if (isTimedOut)
        {
            Log($"Timed out: {filenamesForLog}");
        }
        else
        {
            var filenamesForLog = string.Join(",", files.Select(f => f.Name));
            Log($"File downloaded: {filenamesForLog}");
        }
        
        return files;
    }
