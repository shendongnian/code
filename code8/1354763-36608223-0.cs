    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(htmlstring);
    var items = doc.DocumentNode.SelectNodes("//strong")
                .Select(x => new
                {
                    Name = x.InnerText,
                    Values = x.SelectNodes("../a").Select(a => a.InnerHtml).ToList()
                })
                .ToList();
