    private List<Tuple<string, string, string, string>>
    LoadAllChapters(string htmlCode, string mangaName, CancellationToken cancelToken)
    {
        HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
        htmlDoc.LoadHtml(htmlCode);
        // Don't continue if cancelation is requested
        cancelToken.ThrowIfCancellationRequested();
        var chapterLink = htmlDoc.DocumentNode.SelectNodes(@"//div[@id='chapterlist']//a/@href");
        var chapterName = htmlDoc.DocumentNode.SelectNodes(@"//div[@id='chapterlist']//a/@href/following-sibling::text()[1]").Reverse().ToList();
        var newChapters = new List<Tuple<string, string, string, string>>();
        for (int i = 0; i < chapterLink.Count; i++)
        {
            // Stop the loop if cancellation is requested.
            cancelToken.ThrowIfCancellationRequested();
            var link = "http://" + Uri.Host + chapterLink[i].GetAttributeValue("href", "not found");
            var chName = chapterName[i].OuterHtml.Replace(" : ", "");
            var chapterNumber = chapterLink[i].InnerText;
            newChapters.Add(new Tuple<string, string, string, string>(link, chName, chapterNumber, mangaName));
        }
        return newChapters;
    }
