    public async Task<string> GetHtmlAsync(string url)
    {
        using (var wc = new Webclient())
        {
            var html = await wc.DownloadStringTaskAsync(url);
            //do some dummy work and return
            return html.Substring(1, 20);
        }
    }
    var str1 = await GetHtmlAsync("http://www.google.com");
