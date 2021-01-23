        public static void Main(string[] args)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(link);
                   
            HtmlAgilityPack.HtmlNodeCollection divs = doc.DocumentNode.SelectNodes("//div[contains(@class, 'sr_item sr_item_new') and contains(@class, 'sr_item_default') and contains(@class, 'sr_property_block') and contains(@class, 'sr_flex_layout')and contains(@class, 'card-bigger-price')and contains(@class, 'sr_item--with-value-deal')]");
            foreach (HtmlAgilityPack.HtmlNode n in divs)
            {
                string hotelID = n.GetAttributeValue("data-hotelid", "");
                string dataClass = n.GetAttributeValue("data-class", "");
                string dataScore = n.GetAttributeValue("data-score", "");
                string dataRecommended = n.GetAttributeValue("data-recommended", "");
                string name = n.SelectSingleNode("a").InnerText;
            }
        }
