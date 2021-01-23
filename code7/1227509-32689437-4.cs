    public class Downloader // in WpfApplication.Util namespace
    {
        public event EventHandler<DownloadProgressChangedEventArgs> DownloadProgressChanged;
        public async void Get(string url)
        {
            Uri uri = new Uri(url);
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadProgressChanged += (sender, args) => OnProgressChanged(args);
                await webClient.DownloadDataTaskAsync(uri);
            }
        }
        private void OnProgressChanged(DownloadProgressChangedEventArgs e)
        {
            var handler = DownloadProgressChanged;
            if (handler != null)
                DownloadProgressChanged(this, e);
        }
    }
