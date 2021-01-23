    private static string GetTokenisedText(string untokenised, params string[] tokenKeys)
    {
        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(untokenised);
        var query = doc.DocumentNode.Descendants("input");
        foreach (var item in query.ToList())
        {
            var value = item.GetAttributeValue("name", string.Empty);
            if (!string.IsNullOrEmpty(value))
            {
               var token = tokenKeys.Where(p => p == value).FirstOrDefault();
               if (!string.IsNullOrEmpty(token))
               {
                   item.NextSibling.Remove();
                   var newNode = HtmlAgilityPack.HtmlTextNode.CreateNode(string.Format("{{{{{0}}}}}", token.ToUpper()));
                   item.ParentNode.ReplaceChild(newNode, item);
               }
            }
        }
        return doc.DocumentNode.OuterHtml;
    }
