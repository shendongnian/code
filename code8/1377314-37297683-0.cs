    using System.Net;
    private void CreateDirectoryFTP(string directory)
    {
        string path = @"/" + directory;
        WebRequest request = WebRequest.Create(FtpHost + path);
        request.Method = WebRequestMethods.Ftp.MakeDirectory;
        request.Credentials = new NetworkCredential(FtpUser, FtpPass);
        try
        {
           request.GetResponse();
        }
        catch (Exception e)
        {
            //directory exists
        }
    }
