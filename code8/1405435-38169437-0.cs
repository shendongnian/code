    HtmlWeb web = new HtmlWeb();
    var doc = web.Load("http://www.fuchsonline.com");
    var link = doc.DocumentNode.SelectSingleNode("//div[@id='footertext']/p");
    string rawText = link.InnerText.Trim();
    string decodedText = HttpUtility.HtmlDecode(text); // or WebUtility
    return decodedText;
