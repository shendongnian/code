    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(@"<a href=""/string1/any string here/string2"">text here</a>");
    var links = doc.DocumentNode
                    .SelectNodes("//a[@href]")
                    .Select(a=>a.Attributes["href"].Value)
                    .ToList();
