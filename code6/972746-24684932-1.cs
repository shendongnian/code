    public string GetHtml(string url)
    {
        using (var wc = new Webclient())
        {
            var html = wc.DownloadString(url);
            //do some dummy work and return
            return html.Substring(1, 20);
        }
    }
    var str2 = await Task.Run(()=>GetHtml("http://www.google.com"));
