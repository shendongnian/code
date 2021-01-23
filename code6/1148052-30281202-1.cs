    public static DateTime GetLastModified(string fileUri, NetworkCredential credentials) 
    {
        // error checking omitted
        request = FtpWebRequest.Create(fileUri);
        request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
        request.Credentials = credentials;
        using (var response = (FtpWebResponse)request.GetResponse())
            return response.LastModified;
    }
