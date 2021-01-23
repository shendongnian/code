        [XmlRoot("s")]
        public class request
        {
            [XmlElement("id")]
            public int id { get; set; }
            [XmlElement("title")]
            public string title { get; set; }
            [XmlElement("description")]
            public string description { get; set; }
            [XmlElement("state")]
            public string state { get; set; }
        }​
