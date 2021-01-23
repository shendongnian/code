    private async Task<List<MyItem>> ParseFeed(string text)
    {
        XNamespace ns = "http://mynamespace/";
        return await Task.Run(() =>
        {
            var xdoc = XDocument.Parse(text);
            return (from XElement item in xdoc.Descendants("item")
                    select new
                    {
                        Subject = (string)item.Element(ns + "Subject"),
                        CreationDate =    (System.DateTime)System.DateTime.Parse((string)item.Element(ns + "CreationDate")),
                        ItemID = ns 
                    }).ToList()
						.select(x=> new MyItem{
							x.Subject,
							x.CreationDate, 
							ItemID  = SafeConvert.ToInt32(ns)
						}).ToList();
        });
    }
