    public class Foo
    {
        public string Name { get; set; }
        public Bar Bar { get; set; }
    }
    [XmlRoot("Foo")]
    public class Bar
    {
        [XmlElement("Bar_Data")]
        public string Data { get; set; }
        [XmlElement("Bar_MoreData")]
        public string MoreData { get; set; }
    }
    var foo = (Foo) new XmlSerializer(typeof (Foo)).Deserialize(...);
    var bar = (Bar) new XmlSerializer(typeof (Bar)).Deserialize(...);
    foo.Bar = bar
