    var serializer = new XmlSerializer(typeof(ItemList));
    ItemList items = (ItemList)serializer.Deserialize(reader);
    listView.ItemsSource = items.Items;
    [XmlRoot("Items")]
    public class ItemList
    {
        public ItemList() {Items = new List<Item>();}
        [XmlElement("Item")]
        public List<Item> Items {get;set;}
    }
    
    public class Item
    {
        [XmlElement("Name")]
        public string Name { get; set; }
    
        [XmlElement("State")]
        public string State { get; set; }
    }
