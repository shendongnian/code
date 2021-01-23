    using (ScpClient client = new ScpClient(host, username, password))
    {
        client.Connect();
        using (Stream localFile = File.OpenRead(localFilePath))
        {
             client.Upload(localFile, remoteFilePath);
        }
    }
