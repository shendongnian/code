    // the call to First() will throw an exception if the h3 isn't found.
    // returning an empty HtmlNode will allow you to ignore that
    var node = (HtmlPage.DocumentNode.Descendants("h3")
        .FirstOrDefault( h => 
                h3.Attributes["class"] != null 
                && a.Attributes["class"].Value == "bar")
        ) ?? HtmlPage.CreateElement("h3")) 
        .Elements("a").FirstOrDefault();
    if (node != null)
    {
        string link = node.Attributes["href"].value;
        string username = node.InnerText;
    }
