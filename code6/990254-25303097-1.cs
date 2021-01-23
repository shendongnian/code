    public string Function(string url)
        {
            this.url = url;
            URLParser parser = new URLParser();
            parser.ParseJsonUrl(url, new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted ));
        }
    void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
           //Everything you need to be performed once the string is downloaded
        }
