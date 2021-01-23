    var xdoc = XDocument.Parse(text);
    var list = new List<MyItem>();
    foreach(var item in xdoc.Descendants("item"))
    {
        DateTime creationDate;
        int itemId;
        if(int.TryParse((string)item.Element(ns + "ItemID"),out itemId)
           && DateTime.TryParse((string)item.Element(ns + "CreationDate"), out creationDate))
        {
            list.Add(new MyItem
                {
                    Subject = (string)item.Element(ns + "Subject"),
                    CreationDate = creationDate,
                    ItemID = itemId
                });
        }
    }
    
    return list;
