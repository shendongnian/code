    // DriveService _service: a valid Authendicated DriveService
    // Google.Apis.Drive.v2.Data.File _fileResource: Resource of the file to download. (from service.Files.Get(FileId).Execute();)  
    // string _saveTo: Full file path to save the file
    public static void downloadFile(DriveService _service, File _fileResource, string _saveTo)
    {
        if (!String.IsNullOrEmpty(_fileResource.DownloadUrl))
        {
            try
            {
                var x = _service.HttpClient.GetByteArrayAsync(_fileResource.DownloadUrl);
                byte[] arrBytes = x.Result;
                System.IO.File.WriteAllBytes(_saveTo, arrBytes);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
    }
