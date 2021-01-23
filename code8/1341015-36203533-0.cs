        [XmlRoot(ElementName = "section")]
        public class Section
        {
            [XmlElement(ElementName = "element1")]
            public string Element1 { get; set; }
            [XmlElement(ElementName = "element2")]
            public string Element2 { get; set; }
            [XmlElement(ElementName = "idx")]
            public List<string> Idx { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string Id { get; set; }
        }
        [XmlRoot(ElementName = "contents")]
        public class Contents
        {
            [XmlElement(ElementName = "section")]
            public List<Section> Section { get; set; }
        }
