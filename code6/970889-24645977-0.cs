    WebClient webClient = new WebClient();
    webClient.Headers.Add(HttpRequestHeader.AcceptEncoding, "UTF-8");
    byte[] b = webClient.DownloadData(url);    
    MemoryStream ms = new MemoryStream(b);
    HtmlDocument Doc = new HtmlDocument();
    Doc.load(ms,"UTF-8");
