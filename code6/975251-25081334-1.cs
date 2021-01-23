    List<string> ftpRawList = new List<string>();
    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
    request.Timeout = 60000;
    request.ReadWriteTimeout = 60000;
    request.Credentials = this.credentials;
    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
    {
        Stream data = response.GetResponseStream();
        using (StreamReader reader = new StreamReader(data))
        {
            string responseString = reader.ReadToEnd();
            ftpRawList.AddRange(responseString.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
        }
