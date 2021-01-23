    private void buttonDownload_Click(object sender, EventArgs e)
    {
      WebClient webClient = new WebClient();
      webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
      webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadFileProgressChanged);
      webClient.DownloadFileAsync(new Uri("http://example.com/myfile.xlsx"), @"c:\myfile.xlsx");
    }
    
    private void DownloadFileProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
      // Update the progress bar component
      progressBar.Value = e.ProgressPercentage;
    }
    
    private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
      MessageBox.Show("Download completed!");
    }
