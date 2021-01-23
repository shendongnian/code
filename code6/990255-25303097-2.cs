    public void ParseJsonUrl(string url, DownloadStringCompletedEventHandler handler)
        {
            Uri uri = new Uri(url);
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += handler;
            webClient.DownloadStringAsync(uri);
        }
