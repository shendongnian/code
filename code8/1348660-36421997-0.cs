    using (var client = new WebClient())
    {
       client.Proxy = new WebProxy();
       client.DownloadFile(@tb.Text, Path.Combine(path, "new.png");
    }
    
