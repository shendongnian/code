            var valueList = new List<string>();
            var numList = new List<string>();
            var nameList = new List<string>();
            XmlDocument document = new XmlDocument();
            document.LoadXml(System.Net.WebUtility.HtmlDecode(Resource1.New_Text_Document));
            XmlNode rootnode = document.SelectSingleNode("root");
            XmlNodeList items = rootnode.SelectNodes("./a/div");
            foreach (XmlNode node in items)
            {
                string value = node.SelectSingleNode("//div[contains(concat(' ', @class, ' '), 'market_listing_their_price')]/span/span").InnerText;
                string num = node.SelectSingleNode("//div[contains(concat(' ', @class, ' '), ' market_listing_num_listings ')]/span/span").InnerText;
                string name = node.SelectSingleNode("//span[contains(concat(' ', @class, ' '), ' market_listing_item_name ')]").InnerText;
                valueList.Add(value); //Lowest price for the item
                numList.Add(num); //Volume of that item
                nameList.Add(name); //Name of that item
            }
