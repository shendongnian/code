     private async void DownloadProgress(DownloadOperation download)
    {
      Debug.WriteLine("Callback");
      var value = download.Progress.BytesReceived * 100 / download.Progress.TotalBytesToReceive;
      if (download.Progress.Status == BackgroundTransferStatus.Completed || value >= 100)
      {
        var f = new Field();
        f.Done = true;
        await this.DbConnection.InsertAsync(f);
        Debug.WriteLine("DONE");
      }
