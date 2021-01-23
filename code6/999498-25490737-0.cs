    private string ParseReceiptData(string xmlReceipt)
        {
            Dictionary AttributeDict = new Dictionary();
            var xd = XDocument.Parse(xmlReceipt).Descendants();
            foreach (var node in xd)
            {
                if (node.Name.LocalName.Equals("ProductReceipt"))
                {
                    var attribute = node.Attributes();
                    foreach (var attrib in attribute)
                    {
                        AttributeDict.Add(attrib.Name.LocalName, attrib.Value);
                    }
                }
            }
            var purchaseDate = Convert.ToDateTime(AttributeDict["PurchaseDate"]);
            var Expdate = purchaseDate.Add(TimeSpan.FromDays(30)).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            AttributeDict.Add("ExpiryDate", Expdate);
            return JsonConvert.SerializeObject(AttributeDict);
        }
