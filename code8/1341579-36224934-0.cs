    private async Task DownloadFile()
        {
            IProgress<HttpProgress> progress = new Progress<HttpProgress>(ShowProgress);
            try
            {
                
                response = await httpClient.GetAsync(new Uri(downloadUrl), HttpCompletionOption.ResponseContentRead).AsTask(cts.Token, progress);
            }
            catch { }
            DownloadMessageText.Text = "Download complete. Writing to disk...";
            await WriteToFile();
            DownloadMessageText.Text = "File saved in music library.";
        }
