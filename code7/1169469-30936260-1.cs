        var tables = html.DocumentNode.SelectNodes("//table").ToList();
        List<string> bodyList = new List<string>();
        foreach (var table in tables)
        {
            if (html.DocumentNode != null)
            {
                var images = table.SelectNodes("//img/@src");
    
                if (images.Any())
                {
                    bodyList.AddRange(images.Select(t => t.OuterHtml + (i + 1).ToString());
                }
            }                  
        }
