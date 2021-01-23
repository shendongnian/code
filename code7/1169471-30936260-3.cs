    List<string> bodyList = new List<string>();
    var table = html.DocumentNode.SelectNodes("//table").FirstOrDefault();
    If (table != null)
    {
        bodyList.AddRange(table.SelectNodes("//img/@src").Select(t => t.OuterHtml + (i + 1).ToString());
    }
