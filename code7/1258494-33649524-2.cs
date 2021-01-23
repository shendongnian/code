    class CopyDownloader
    {
        public event DownloadProgressChangedEventHandler ProgressChanged;
        private void WebClientOnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
        {
            if(ProgressChanged != null)
            {
                ProgressChanged(this, downloadProgressChangedEventArgs);
            }
        }
            
        public CopyDownloader()
        {
             webClient.DownloadFileCompleted += WebClientOnDownloadFileCompleted;
             webClient.DownloadProgressChanged += WebClientOnDownloadProgressChanged;
        }
        // ...
    }
            
