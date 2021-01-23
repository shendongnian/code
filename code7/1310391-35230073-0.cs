    private void StartDownload(string DownloadSource, string SaveLocation)
        {
            try
            {
                Thread thread = new Thread(() =>
                {
                    WebClient client = new WebClient();
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client.DownloadFileAsync(new Uri(DownloadSource), SaveLocation);
                });
                thread.Name = "aFieldDownload";
                thread.Start();
            }
            catch (Exception err)
            {
                DownloadPercent = 999;
            }
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            byteHasBeenDownloaded = true;
            try
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                DownloadPercent = int.Parse(Math.Truncate(percentage).ToString());
            }
            catch (Exception err)
            {
                DownloadPercent = 999;
            }
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (byteHasBeenDownloaded)
            {
                DownloadFinishTime = DateTime.Now;
                UpdateActionDuration(false);
            }
        }
