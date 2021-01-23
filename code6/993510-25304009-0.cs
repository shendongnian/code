    [XmlRoot(ElementName="Foo")]
    public class Foo
    {
        [XmlElement(ElementName="Bar")]
        public int Bar { get; set; }
        public bool ShouldSerializeBar()
        {
            return (Bar > 10);
        }
    }
