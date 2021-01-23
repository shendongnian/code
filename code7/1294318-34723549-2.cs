    string text = "<p>test <span> <font> here </font> </span> try</p><p> <font> try 2</font> </p>"
    StringBuilder sbtexttoCorrect = new StringBuilder();
    HtmlDocument html = new HtmlDocument();
    html.LoadHtml(text);
    var nodes = html.DocumentNode.SelectNodes("//p");
    foreach (var line in nodes)
    {
        foreach (var n in line.ChildNodes)
        {
            if (n.Name != "span")
            {
                sbtexttoCorrect.Append(n.InnerText);
            }
        }
    }
