    public async void Main()
    {
        WebClientEx webClient = new WebClientEx();  // <= use WebClientEx
        webClient.Credentials = new NetworkCredential("myuser", "password", "https://example.com/Login.htm");
    
        // Add headers here ------------
        webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.79 Safari/537.36");
        webClient.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
        webClient.Headers.Add("Accept-Language", "en-US,en;q=0.5");
        webClient.Headers.Add("Accept-Encoding", "gzip, deflate");
        webClient.Headers.Add("Cache-Control", "max-age=0");
        webClient.Headers.Add("DNT", "1");
        //------------------------------
    
        webClient.DownloadFileTaskAsync(new Uri("https://example.com/#/FROMsender/EXTERNAL_20160706.zip"), @"C:\temp\Test\EXTERNAL_20160706.zip").Wait();
        while (webClient.IsBusy) Thread.Sleep(1000);
    
        Dts.TaskResult = (int)ScriptResults.Success;
    }
