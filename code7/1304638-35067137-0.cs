    public class Applications
    {
        [XmlElement("AccessibleApplication")]
        public List<Application> AccessibleApplications { get; set; }
        [XmlElement("EligibleApplication")]
        public List<Application> EligibleApplications { get; set; }
    }
    public class Application
    {
        [XmlText]
        public string Value { get; set; }
    }
