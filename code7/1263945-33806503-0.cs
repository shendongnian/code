    private async void progressChanged(DownloadOperation downloadOperation)
    {
        var status = downloadOperation.Progress.Status;
        if (status == BackgroundTransferStatus.Completed || status == BackgroundTransferStatus.Error)
        {
            await UpdateUI(downloadOperation);
        }
    }
    private async Task UpdateUI(DownloadOperation downloadOperation)
    {
        await this.Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
        {
            activeDownloads.Remove(downloadOperation);
            var activeCount = activeDownloads.Count;
            progressBar1.Value = activeCount;
            progressCount.Text = activeCount.ToString();
        });
    }
