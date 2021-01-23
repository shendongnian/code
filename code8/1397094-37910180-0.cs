    foreach (HtmlNode node1 in doc.DocumentNode.SelectNodes("//table[@id='searchResultsTable']"))
    {
      foreach (HtmlNode tr in table.SelectNodes("//tr"))
      {
        var @class = tr.GetAttributeValue("class", string.Empty);
        switch (@class) {
              // rest of your parsing
        }
      }
    }
