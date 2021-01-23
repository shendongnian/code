    [XmlInclude(typeof(Foo))]
    [XmlInclude(typeof(Bar))]
    [XmlRoot(ElementName = "Foo")]
    public class FooBar
    {
        [XmlElement(ElementName = "Data")]
        public object Data { get; set; }
        public bool ShouldSerializeData()
        {
            return (Data.GetType() == typeof(Foo));
        }
    }
    [XmlRoot(ElementName="Foo")]
    public class Foo
    {
        [XmlElement(ElementName="Bar")]
        public int Bar { get; set; }
    }
    [XmlRoot(ElementName = "Bar")]
    public class Bar
    {
        [XmlElement(ElementName = "Foo")]
        public int Foo { get; set; }
    }
