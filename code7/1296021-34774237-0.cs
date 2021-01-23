    int itemId;
    return (from XElement item in xdoc.Descendants("item")
            where int.TryParse(item.Element(ns + "ItemID"), out itemId)
            select new MyItem
            {
                Subject = (string)item.Element(ns + "Subject"),
                CreationDate = (System.DateTime)System.DateTime.Parse((string)item.Element(ns + "CreationDate")),
                ItemID = itemId
            }).ToList();
