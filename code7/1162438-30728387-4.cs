    var links = new List<GeckoElement>()
    foreach(var link in browser.Document.Links) {
       if(!String.IsNullOrEmpty(link.GetAttribute("href").ToString()))
          links.Add(link);
    }
    if(links.Count > 0)
       ((GeckoHtmlElement)links[new Random().Next(0, links.Count)]).Click()
    else
       MessageBox.Show("No Links found")
