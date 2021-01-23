    public class Item
    {
        public string Name { get; set; }
        public List<Item> Children { get; set; }
        public Item()
        {
            Children = new List<Item>();
        }
    }
