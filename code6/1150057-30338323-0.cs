    private Task LoadAllChaptersAsync(string htmlCode, string mangaName)
    {
        return Task.Run(() => {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(htmlCode);
            var chapterLink = htmlDoc.DocumentNode.SelectNodes(@"//div[@id='chapterlist']//a/@href");
            var chapterName = htmlDoc.DocumentNode.SelectNodes(@"//div[@id='chapterlist']//a/@href/following-sibling::text()[1]").Reverse().ToList();
            for (int i = 0; i < chapterLink.Count; i++)
            {
                var link = "http://" + Uri.Host + chapterLink[i].GetAttributeValue("href", "not found");
                var chName = chapterName[i].OuterHtml.Replace(" : ", "");
                var chapterNumber = chapterLink[i].InnerText;
                // Note: race conditions/cross thread access possible on the 'Chapters' list instance.
                Chapters.Add(new Tuple<string, string, string, string>(link, chName, chapterNumber, mangaName));
            }
        });
    }
