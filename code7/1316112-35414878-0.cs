    List<CheckBoxListItem> items = new List<CheckBoxListItem>();
    var nodes = Web.DocumentNode.SelectNodes("//a[@title and @href]");
    if (nodes != null)
    {
       foreach (var node in nodes)
       {
          items.Add(new CheckBoxListItem()
          {
            Text = node.Attributes["title"].Value,
            Href = node.Attributes["href"].Value
          });
       }
    }
