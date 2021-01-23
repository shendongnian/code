    [XmlRoot(Namespace = "http://www.w3.org/2005/Atom")]
    public struct Parameter
    {
        [XmlAttribute("name")]
        public string ElementName { get; set; } // Added property.
        [XmlAttribute("displayName")]
        public string DisplayName { get; set; } // Changed from Name to DisplayName
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("typeOfParameter")]
        public string DataType { get; set; }
        [XmlText]
        public string Value { get; set; }
        [XmlAttribute("units")]
        public string Units { get; set; }
    }
