        [XmlRoot("Book")]
        public class Book
        {
            [XmlElement("Title")]
            public string Title { get; set; }
            [XmlElement("ISBN")]
            public ISBN isbn { get; set; }
        }
        [XmlRoot("ISBN")]
        public class ISBN
        {
            [XmlAttribute("friendlyName")]
            public string friendlyName { get; set; }
            [XmlText]
            public string value { get; set; }
        }​
