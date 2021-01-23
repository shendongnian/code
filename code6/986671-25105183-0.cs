    public static readonly int BufferSize = 4096;
    int receivedBytes = 0;
    WebClient client = new WebClient();
    using (var stream = await client.OpenReadTaskAsync(urlToDownload))
    using (MemoryStream ms = new MemoryStream())
    {
        var buffer = new byte[BufferSize];
        int read = 0;
        while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            ms.Write(buffer, 0, read);
            receivedBytes += read;
            if (progessReporter != null)
            {
               DownloadBytesProgress args = 
                 new DownloadBytesProgress(urlToDownload, receivedBytes, totalBytes);
               progessReporter.Report(args);
             }
        }
        return ms.ToArray();
      }
    }
