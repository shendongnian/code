    void DownloadFtpDirectory(string url, NetworkCredential credentials, string localPath)
    {
        FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(url);
        listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        listRequest.Credentials = credentials;
        List<string> lines = new List<string>();
        using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
        using (Stream listStream = listResponse.GetResponseStream())
        using (StreamReader listReader = new StreamReader(listStream))
        {
            while (!listReader.EndOfStream)
            {
                lines.Add(listReader.ReadLine());
            }
        }
        foreach (string line in lines)
        {
            string[] tokens =
                line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[8];
            string permissions = tokens[0];
            string localFilePath = Path.Combine(localPath, name);
            string fileUrl = url + name;
            if (permissions[0] == 'd')
            {
                Directory.CreateDirectory(localFilePath);
                DownloadFtpDirectory(fileUrl + "/", credentials, localFilePath);
            }
            else
            {
                FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                downloadRequest.Credentials = credentials;
                using (FtpWebResponse downloadResponse =
                          (FtpWebResponse)downloadRequest.GetResponse())
                using (Stream sourceStream = downloadResponse.GetResponseStream())
                using (Stream targetStream = File.Create(localFilePath))
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    while ((read = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        targetStream.Write(buffer, 0, read);
                    }
                }
            }
        }
    }
