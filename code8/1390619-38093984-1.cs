    string url = "http://bet.hkjc.com";
    using(WebClient webClient = new DecompressWebClient())
    {
        string html = webClient.DownloadString(url);
        File.WriteAllText("page.html", html);
    }
