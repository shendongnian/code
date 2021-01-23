    HttpClient client = new HttpClient();
    var html = await client.GetStringAsync("http://google.com");
    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var links = doc.DocumentNode.Descendants()
                    .Where(x => x.Name == "a")
                    .Select(x=>x.Attributes["href"].Value)
                    .ToList();
