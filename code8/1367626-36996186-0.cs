        [XmlAttribute]
        public string Id { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlElement("Directory")]
        public Directory[] Directories { get; set; }
    }`
