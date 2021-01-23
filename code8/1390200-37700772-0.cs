         public class Item
            {
                [XmlElement("title")]
                public string title { get; set; }
                [XmlElement("description")]
                public string description { get; set; }
                [XmlElement("enclosure")]
                public Enclosure enclosure { get; set; }
                [XmlElement("pubDate")]
                public string pubDate { get; set; }
                [XmlElement("link")]
                public string link { get; set; }
            }
        
        public class Enclosure 
        {
            [XmlAttribute("url")]
            public string Url { get; set; }
        //if enclosure has any child elements it comes under XmlElement like this
        // [XmlElement("enclosurechildelement")]
        // public string enclosurechildelement { get; set; }
    
    
        }
