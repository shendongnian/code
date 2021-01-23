    private void CreateDirectoryFTP(string directory, DateTime date)
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
        string pathToDay = path + "/" + date.Day.ToString();
        // And now you can create the subfolder like you did it for the main folder
        string pathToMonth = path + "/" + date.Month.ToString();
        // Also with the month and the year you can do it like you did it for the main folder
    }
