    public async Task Download(string remoteFilePath, string localFilePath)
    {
        using (var response = await client.Files.DownloadAsync(remoteFilePath))
        {
          using (var fileStream = File.Create(localFilePath))
          {
             response.GetContentAsStreamAsync().Result.CopyTo(fileStream);
          }
        }
    }
