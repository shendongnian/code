    private async Task<List<MyItem>> ParseFeed(string text)
    {
        XNamespace ns = "http://mynamespace/";
        return await Task.Run(() =>
        {
            var xdoc = XDocument.Parse(text);
            return (from XElement item in xdoc.Descendants("item")
                    let possibleItemID = GetItemIdIfExists(item.Element(ns + "ItemID"));
                    where possibleItemID.Item1
                    select new MyItem
                    {
                        Subject = (string)item.Element(ns + "Subject"),
                        CreationDate = (System.DateTime)System.DateTime.Parse((string)item.Element(ns + "CreationDate")),
                        ItemID = possibleItemID.Item2                    }).ToList();
        });
    }
    private static Tuple<bool, int> GetItemIdIfExists(object item)
    {
        try
        {
            return Tuple.Create(true, (int)item);
        }
        catch
        {
            return Tuple.Create(false, 0);
        }
    }
