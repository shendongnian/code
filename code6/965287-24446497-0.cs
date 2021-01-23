    using (WebClient client = new WebClient())
    {
        client.DownloadFile(remoteFilename, localFilename);
        ...
    }
