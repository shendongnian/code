    public class SubContainer
    {
        public int DefaultValue { get; set; }
        public List<SubItem> SubItems { get; set;}
    }
    
    public class SubItem
    {
        public int DefaultValue { get; set; }
    }
    
    public class Root
    {
        public List<SubContainer> SubContainers { get; set; }
    }
