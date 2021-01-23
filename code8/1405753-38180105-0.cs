    var doc = XDocument.Load(url);
    foreach (var link in doc.Descendants("link")
    {
        link.Value = WebUtility.UrlDecode(link.Value);
    }
    using (var reader = doc.CreateReader())
    {
        SyndicationFeed.Load(reader);
    }
