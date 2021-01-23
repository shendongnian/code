    public void DownloadImagesFromUrl(string url, string folderImagesPath)
    {
        var uri = new Uri(url);
        HtmlDocument doc = new HtmlDocument(); 
        WebClient wc = new WebClient();
        doc.LoadHtml(wc.DownloadString(uri));
        doc.DocumentNode.SelectNodes("//img")
            .Select(node => Tuple.Create(new UriBuilder(uri.Scheme, uri.Host, uri.Port, node.Attributes["src"].Value).Uri, new WebClient()))
            .AsParallel()
            .ForAll(t => t.Item2.DownloadFile(t.Item1, Path.Combine(folderImagesPath, Path.GetFileName(t.Item1.ToString()))));
    }
