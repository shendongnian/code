            HtmlAgilityPack.HtmlWeb hw = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = hw.Load("https://www.test.com");
            var hrefs = (from image in doc.DocumentNode.Descendants()
                            where image.Name == "img" &&
                                image.ParentNode.Name == "a"
                            select image.ParentNode).ToList();
            foreach (var href in hrefs)
            {
                newHtmls.Add(href.GetAttributeValue("href", ""));
            }
