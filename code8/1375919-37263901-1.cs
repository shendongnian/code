    [XmlRoot("main")]
    public class Main
    {
        public List<Rate> Rates { get; set; }
    }
    
    public class Rate
    {
        public string Value { get; set; }
    }
