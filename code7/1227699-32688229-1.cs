    public class ItemsRoot
    {
        public List<Item> ItemList { get; set; }
    }
    public class Item
    {
        public string Name { get; set; }
        public List<Item> ItemList { get; set; }
    }
