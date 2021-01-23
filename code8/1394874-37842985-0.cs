    public class ExampleClass
    {
        [XmlElement]
        public decimal Something { get; set; }
        [XmlIgnore]
        public bool SomethingSpecified { get; set; }
    }
