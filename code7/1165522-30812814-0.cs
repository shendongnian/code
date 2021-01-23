    [XmlRoot("LiveUpdate")]
    public class Client
    {
        public string CityID { get; set; }
        public string CityName { get; set; }
        public string UserName { get; set; }
        [XmlArray("ApplicationDetails")]
        [XmlArrayItem("ApplicationDetail")]
        public List<Apps> AppList { get; set; }
    }
    public class Apps
    {
        [XmlAttribute]
        public string Application { get; set; }
        [XmlAttribute]
        public bool Licensed { get; set; }
        [XmlAttribute]
        public string Version { get; set; }
        [XmlAttribute]
        public string Patch { get; set; }
    }
