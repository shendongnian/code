       public string GetContent(string url)
        {
    
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load(url);
            HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[@id='t1']");
    
            return node.InnerHtml;
        }
