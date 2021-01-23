    HtmlAgilityPack.HtmlWeb webpage = new HtmlAgilityPack.HtmlWeb();
    HtmlAgilityPack.HtmlDocument webdoc = webpage.Load("https://support.microsoft.com/en-us/kb/894199");
    var htmlresult = webdoc.DocumentNode;
    var list = new List<string>();
    foreach(HtmlAgilityPack.HtmlNode link in htmlresult.SelectNodes("//a[@href]"))
    {
       list.Add(link.GetAttributeValue("href", string.Empty));
    }
    
    list.ForEach(Console.WriteLine);
