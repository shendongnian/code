    public static void RunRequest(Uri uri, Action<string> onCompleted)  
    {
        var client = new WebClient();
        client.DownloadStringCompleted += (sender, e) => onCompleted(e.Result);
        client.DownloadStringAsync(uri);
    };
