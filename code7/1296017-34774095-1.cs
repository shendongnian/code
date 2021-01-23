    private async Task<List<MyItem>> ParseFeed(string text)
    {
        XNamespace ns = "http://mynamespace/";
        return await Task.Run(() =>
        {
            var xdoc = XDocument.Parse(text);
            return (from XElement item in xdoc.Descendants("item")
                    let possibleItemID = item.Element(ns + "ItemID").ParseInt()
                    where possibleItemID.HasValue
                    select new MyItem
                    {
                        Subject = (string)item.Element(ns + "Subject"),
                        CreationDate = (System.DateTime)System.DateTime.Parse((string)item.Element(ns + "CreationDate")),
                        ItemID = possibleItemID.Value
                    }).ToList();
        });
    }
