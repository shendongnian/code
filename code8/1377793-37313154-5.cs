    [XmlRoot("TestXML")]
    public class TestXML
    {
        [XmlElement("Fir")]
        public string Fir { get; set; }
        [XmlArray("TestXML1")]
        [XmlArrayItem("TestXML3", IsNullable = false)]
        public TestXML3[] testxml3 { get; set; }
    }
    public class TestXML3
    {
        [XmlElement("For")]
        public int For { get; set; }
    }
    public class Order
    {
        [XmlElement("number")]
        public string Number { get; set; }
    }
