    /// <summary>
    /// Method to download stock file from ftp server.
    /// </summary>
    /// <param name="stockFileDir"></param>
    /// <param name="supplierId"></param>
    /// <param name="stockFileNamePattern"></param>
    /// <returns></returns>
    public string DownloadStockFile(string stockFileDir, int supplierId, string stockFileNamePattern)
    {
        // Init
        string localFilePath = "";
        // Load remote ftp server file
        using (FtpClient conn = new FtpClient())
        {
            // Set connection details
            conn.Encoding = Encoding.UTF8;
            conn.Host = ftpHost;
            conn.Port = ftpPort;
            conn.ConnectTimeout = 1000 * ftpTimeout;
            conn.Credentials = new NetworkCredential(ftpUser, ftpPass);
            conn.EnableThreadSafeDataConnections = false;
            // Get file listng
            foreach (FtpListItem ftpListItem in conn.GetListing(stockFileDir, FtpListOption.Modify | FtpListOption.Size))
            {
                // Proceed if this is a file
                if (ftpListItem.Type == FtpFileSystemObjectType.File && ftpListItem.Name.Contains(stockFileNamePattern))
                {
                    // Download file
                    localFilePath = string.Format(@"{0}\{1}_{2}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), supplierId, ftpListItem.Name);
                    if (File.Exists(localFilePath)) File.Delete(localFilePath);
                    using (var ftpStream = conn.OpenRead(ftpListItem.FullName))
                    using (var fileStream = File.Create(localFilePath, (int)ftpStream.Length))
                    {
                        var buffer = new byte[8 * 1024];
                        int count;
                        while ((count = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, count);
                        }
                        // Stop further processing
                        break;
                    }
                }
            }
            // Disconnect
            conn.Disconnect();
        }
        // Finished
        return localFilePath;
    }
