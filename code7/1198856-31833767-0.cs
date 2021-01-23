    var html = @"<site><link>Hello World</link><name>Fred</name></site>";
    HtmlNode.ElementsFlags.Remove("link");  //remove link from list of special tags
    var doc = new HtmlDocument();
    doc.LoadHtml(html);
    Console.WriteLine(doc.DocumentNode.OuterHtml);
    var links = doc.DocumentNode.SelectNodes("//link");
    foreach (HtmlNode link in links)
    {
    	Console.WriteLine(link.InnerText);
    }
