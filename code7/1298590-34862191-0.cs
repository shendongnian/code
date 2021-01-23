    //// Get the object used to communicate with the server.
    var request =
        (FtpWebRequest)
            WebRequest.Create("ftp://" + ftpServer + @"/" + remotePath + @"/" +
                              entry.FullName.TrimEnd('/'));
    
    //// Determine if we are transferring file or directory
    if (string.IsNullOrWhiteSpace(entry.Name) && !string.IsNullOrWhiteSpace(entry.FullName))
        request.Method = WebRequestMethods.Ftp.MakeDirectory;
    else
        request.Method = WebRequestMethods.Ftp.UploadFile;
    
    //// Try to transfer file
    try
    {
        //// This example assumes the FTP site uses anonymous logon.
        request.Credentials = new NetworkCredential(user, password);
    
        switch (request.Method)
        {
            case WebRequestMethods.Ftp.MakeDirectory:
                break;
    
            case WebRequestMethods.Ftp.UploadFile:
                var buffer = new byte[8192];
                using (var rs = request.GetRequestStream())
                {
                    StreamUtils.Copy(entry.Open(), rs, buffer);
                }
    
                break;
        }
    }
    catch (Exception ex)
    {
        //// Handle it!
        LogHelper.Error<FtpHelper>("Could not extract file from package.", ex);
    }
    finally
    {
        //// Get the response from the FTP server.
        var response = (FtpWebResponse) request.GetResponse();
    
        //// Close the connection = Happy a FTP server.
        response.Close();
    }
