    private async void DownloadProgress(DownloadOperation download)
    {
        Debug.WriteLine("Callback");
        var value = download.Progress.BytesReceived * 100 download.Progress.TotalBytesToReceive;
        new System.Threading.ManualResetEvent(false).WaitOne(1000);
        if (download.Progress.Status == BackgroundTransferStatus.Completed )
        {
            var f = new Field();
            f.Done = true;
            await this.DbConnection.InsertAsync(f);
            Debug.WriteLine("DONE");
        }
    }
