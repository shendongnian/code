    using (WebClient wc = new WebClient())
    {
        string html = wc.DownloadString("http://www.foo.bar/"); // Change as required.
        HtmlAgilityPack.HtmlDocument h = new HtmlAgilityPack.HtmlDocument();
        h.LoadHtml(html);
    }
