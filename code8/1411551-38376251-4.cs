    public class SomeClass
    {
        public List<SomeItem> Items { get; set; }
    }
    public class SomeItem
    {
        [Key]
        public int TheKey { get; set; }
        public string SomeValue { get; set; }
    }
