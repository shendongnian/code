    [XmlRoot("phrase")]
    public class Phrase
    {
        [XmlElement("q")]
        public List<string> q { get; set; }
        [XmlAttribute("level")]
        public int Level { get; set; }
        [XmlElement("subject")]
        public string Subject { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
