    public class ContainerClass
    {
        public string Text { get; set; }
        public List<Item> Items { get; set; }
        public ContainerClass()
        {
            Items = new List<Item>();
        }
    }
