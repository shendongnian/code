    var s = "<ItemsRoot><ItemList><Item><Name>A</Name><ItemList><Item><Name>AA</Name><ItemList><Item><Name>AAA</Name><ItemList><Item><Name>AAAA</Name><ItemList><Item><Name>AAAAA</Name></Item><Item><Name>ABBBB</Name></Item></ItemList></Item><Item><Name>ABBB</Name></Item></ItemList></Item><Item><Name>ABB</Name></Item></ItemList></Item><Item><Name>AB</Name></Item></ItemList></Item><Item><Name>B</Name></Item></ItemList></ItemsRoot>";
    var type = new XmlSerializer(typeof(ItemsRoot));
    var obj = type.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(s.ToCharArray())));
    var reflectedType = ((ItemsRoot)obj).ItemList.Select((item, index) => new Item
            {
                Index = index,
                ItemList = Find(item),
                Name = item.Name
            });
    static List<Item> Find(Item item)
    {
            return item.ItemList.Select((j, k) => new Item
        {
         Name = j.Name,
         ItemList = Find(j),//j.ItemList,
         Index = k//Find(item.ItemList, j)
        }).ToList();
    }
