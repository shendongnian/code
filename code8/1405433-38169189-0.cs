    public string getvalue()
            {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc =web.Load("www.fuchsonline.com");
            var link = doc.DocumentNode.SelectNodes("//div[@id='footertext']");
            return link.InnerText.ToString();
           }
