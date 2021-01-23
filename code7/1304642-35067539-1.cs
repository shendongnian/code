    [XmlRoot]
    public class Applications
    {
        [XmlElement("AccessibleApplication")]
        public string[] AccessibleApplication { get; set; }
        [XmlElement("EligibleApplication")]
        public string[] EligibleApplication { get; set; }
    }
