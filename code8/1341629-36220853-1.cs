        [XmlRoot(ElementName = "lijst_item")]
        public class Lijst_item
        {
            [XmlElement(ElementName = "id")]
            public string Id { get; set; }
            [XmlElement(ElementName = "naam")]
            public string Naam { get; set; }
            [XmlElement(ElementName = "archived")]
            public string Archived { get; set; }
        }
        [XmlRoot(ElementName = "lijst")]
        public class Lijst
        {
            [XmlElement(ElementName = "lijst_item")]
            public List<Lijst_item> Lijst_item { get; set; }
        }
