    public class Road
    {
        [XmlElement("Group")]
        public List<Group> Groups { get; set; }
    }
    public class Group
    {
        [XmlElement("Group")]
        public List<Group> Groups { get; set; }
        [XmlAttribute]
        public string Caption { get; set; }
    }
