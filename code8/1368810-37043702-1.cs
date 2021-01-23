    void DownloadFtpDirectory(string remotePath, NetworkCredential credentials, string localPath)
    {
        FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(remotePath);
        listRequest.UsePassive = true;
        listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        listRequest.Credentials = credentials;
        using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
        using (Stream listStream = listResponse.GetResponseStream())
        using (StreamReader listReader = new StreamReader(listStream))
        {
            while (!listReader.EndOfStream)
            {
                string line = listReader.ReadLine();
                string[] tokens = line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[8];
                string permissions = tokens[0];
                string localFilePath = Path.Combine(localPath, name);
                string remoteFilePath = remotePath + name;
                if (permissions[0] == 'd')
                {
                    Directory.CreateDirectory(localFilePath);
                    DownloadFtpDirectory(remoteFilePath + "/", credentials, localPath);
                }
                else
                {
                    FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(remoteFilePath);
                    downloadRequest.UsePassive = true;
                    downloadRequest.UseBinary = true;
                    downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                    downloadRequest.Credentials = credentials;
                    using (FtpWebResponse downloadResponse = (FtpWebResponse)downloadRequest.GetResponse())
                    using (StreamReader downloadReader = new StreamReader(downloadResponse.GetResponseStream()))
                    using (StreamWriter writer = new StreamWriter(localFilePath))
                    {
                        writer.Write(downloadReader.ReadToEnd());
                    }
                }
            }
        }
    }
