    [Serializable()]
    
        [XmlRoot(ElementName = "FPC")]
        public class FPC
        {
            [XmlAttribute(AttributeName = "Name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
            [XmlAttribute(AttributeName = "Updated")]
            public string Updated { get; set; }
        }
    
        [XmlRoot(ElementName = "FpcBlock")]
        public class FpcBlock
        {
            [XmlElement(ElementName = "FPC")]
            public List<FPC> FPC { get; set; }
        }
