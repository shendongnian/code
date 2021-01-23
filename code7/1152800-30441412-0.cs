      private void button1_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            string sourceFile = @"\\server\test.txt";
            string destFile = @"\\server2\test2.txt";
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri(sourceFile), destFile);
        }
    private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("The download is completed!");
        }
