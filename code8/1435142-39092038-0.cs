    public class Item
    {
        public int Id { get; set; }
        public string AdContent { get; set; }
    }
    
    public class RootObject
    {
        public List<Item> items { get; set; }
    }
