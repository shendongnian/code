    public static byte[] DownloadFile(DriveService driveService, string fileId)
    {
        var file = driveService.Files.Get(fileId).Execute();
        return driveService.HttpClient.GetByteArrayAsync(file.DownloadUrl).Result;
    }
