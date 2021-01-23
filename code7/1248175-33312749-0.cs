    public class iTunes 
    {
        public List<Category> Categories { get; set; }
    }
    
    public class Category
    {
        [XmlAttribute("category")]
        public string category { get; set; }
    }
