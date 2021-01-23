    //using for IDisposable.Dispose()
    using (WebClient client = new WebClient())
    {
        string html = client.DownloadString("http://stackoverflow.com");
        //Do something with html then
    }
