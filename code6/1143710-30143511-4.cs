    var node = HtmlPage.DocumentNode.Descendants("a")
        .Where(a =>
            a.Ascendants("h3")
                .Any(h3 =>
                    h3.Attributes["class"] != null 
                    && a.Attributes["class"].Value == "bar"
                )
        )
        .Where(a => 
            a.Attributes["title"] != null 
            && a.Attributes["title"].Value == "Profile View"
            && a.Attributes["href"] != null
        )
        .FirstOrDefault();
    if (node != null)
    {
        string link = node.Attributes["href"].value;
        string username = node.InnerText;
    }
