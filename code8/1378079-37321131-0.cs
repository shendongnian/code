    string s = "<p>firt paragraph</p>some <br />text<p>another paragraph</p><span>some text between span</span><p>hellow word</p>";
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(s);
    var nodes = doc.DocumentNode.SelectNodes("//p");
    foreach (var item in nodes)
    {
    	Console.WriteLine(item.OuterHtml);
    }
