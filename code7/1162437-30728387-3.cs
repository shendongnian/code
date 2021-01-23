    var links = new List<GeckoElement>()
    foreach(var link in browser.Document.Links) {
       if(String.IsNullOrEmpty(link.GetAttribute("href").ToString()))
          links.Add(link);
    }
    ((GeckoHtmlElement)links[new Random().Next(1, links.Count)]).Click()
