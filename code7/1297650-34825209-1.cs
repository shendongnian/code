     HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
     doc.LoadHtml(result);
     foreach (HtmlNode link in doc.DocumentNode.SelectNodes("a"))
            {
                string value = link.InnerText; // here you can get href value 
            }
