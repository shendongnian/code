    [XmlRoot]
    public class Applications
    {
        [XmlElement("AccessibleApplication")]
        public List<string> AccessibleApplication { get; set; }
        [XmlElement("EligibleApplication")]
        public List<string> EligibleApplication { get; set; }
    }
