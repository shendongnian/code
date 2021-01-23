    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(Properties.Resources.HtmlContents);
    var text = doc.DocumentNode.SelectNodes("//body//text()").Select(node => node.InnerText);
    StringBuilder output = new StringBuilder();
    foreach (string line in text)
    {
       output.AppendLine(line);
    }
    string textOnly = HttpUtility.HtmlDecode(output.ToString());
