    var web = new HtmlWeb();
    var document = web.Load(completeurl);
    
    if (web.StatusCode == HttpStatusCode.OK)
    {
        var urls = document.DocumentNode.Descendants("img")
              .Select(e => e.GetAttributeValue("src", null))
              .Where(s => !String.IsNullOrEmpty(s)).ToList();
    }
