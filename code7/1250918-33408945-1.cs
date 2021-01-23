    var links = document.DocumentNode.SelectNodes("//a[@class='picRind history-item ']|//a[@class='picRind history-item j-p4plog']").Select(a => a.Attributes["href"].Value).Distinct();
    foreach (var link in links)
    {
        Console.WriteLine(link);
    }
    var lazyContent = new HtmlDocument();
    lazyContent.LoadHtml(document.DocumentNode.SelectNodes("//script[@id='lazy-render']").First().ChildNodes[0].InnerHtml);
    var lazyLinks = lazyContent.DocumentNode.SelectNodes("//a[@class='picRind history-item ']|//a[@class='picRind history-item j-p4plog']")
                    .Select(a => a.Attributes["href"].Value)
                    .Distinct();
    foreach (var link in lazyLinks)
    {
        // Prints the remaining 36 product links
        Console.WriteLine(link);
    }
