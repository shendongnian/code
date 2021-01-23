    HtmlWeb web = new HtmlWeb();
    HtmlDocument doc = web.Load(Url);
    var data = doc.DocumentNode.Descendants()
                   .Where(n => n.GetAttributeValue("style",   "").Equals("display: none")).FirstOrDefault();
    string version = String.Empty;
    if (data!= null)
    {
      version = data.InnerText;
    }
