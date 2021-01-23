    public class Example
    {
        public int x { get; set; }
        [XmlIgnore]
        public bool xSpecified;
        public Example()
        {
            xSpecified = <set your value for this class>;
        }
    }
