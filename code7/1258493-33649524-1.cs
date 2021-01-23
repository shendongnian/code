    class CopyDownloader
    {
        public string RemoteFileUrl { get; set; }
        public string LocalFileName { get; set; }
        WebClient webClient = new WebClient();
        public CopyDownloader()
        {
            webClient.DownloadFileCompleted += WebClientOnDownloadFileCompleted;
        }
        public void StartDownload()
        {
            var tempFileName = Path.GetTempFileName();
            webClient.DownloadFile(RemoteFileUrl, tempFileName, tempFileName)
        }
        private void WebClientOnDownloadFileCompleted(object sender, AsyncCompletedEventArgs asyncCompletedEventArgs)
        {
            string tempFileName = asyncCompletedEventArgs.UserState as string;
            File.Copy(tempFileName, GetUniqueFileName());
        }
        private string GetUniqueFilename()
        {
            // Create an unused filename based on your original local filename or the remote filename
        }
    }
