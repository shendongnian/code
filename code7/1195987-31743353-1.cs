    public class Template
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }
    }
    public class Item
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
    public class Profile
    {
        public string Name { get; set; }
        public string TemplateName { get; set; }
    }
