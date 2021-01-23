    [XmlRoot(Namespace = "", ElementName = "param")]
    public class Param
    {
        [XmlElement("professor")]
        public List<professor> Professor { get; set; }
        [XmlElement("course")]
        public List<course> Course { get; set; }
    }
    public class professor
    {
        [XmlAttribute("id")]
        public int professorid;
        [XmlAttribute("name")]
        public string professorname;
        public professor() { }
    }
    public class course
    {
        [XmlAttribute("id")]
        public int courseid;
        [XmlAttribute("name")]
        public string coursename;
        public course() { }
    }
