    static void DownloadData()
    {
        string url = "http://google.com";
        WebClient client = new WebClient();
        client.DownloadDataCompleted += DownloadDataCompleted;
        client.DownloadDataAsync(new Uri(url));
    }
    static void DownloadDataCompleted(object sender,
    DownloadDataCompletedEventArgs e)
    {
        // Handle returned data here
    }
