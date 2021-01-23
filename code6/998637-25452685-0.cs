    private async Task startDownloadAsync(string link, string savePath)
    {      
      using (var client = new WebClient())
      {
        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
        await client.DownloadFileTaskAsync(new Uri(link), savePath);              
      }
    }
    private async void checkUpdateButton_Click(object sender, EventArgs e)
    {           
      await startDownloadAsync(versionLink, versionSaveTo);
      checkVersion();
    }
