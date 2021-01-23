    [Serializable]
    public class JMF
    {
        [XmlAttribute("SenderID")]
        public string SenderID { get; set; }
        [XmlAttribute("Version")]
        public string Version { get; set; }
        public Command Command { get; set; }
    }
    [Serializable]
    public class Command
    {
        [XmlAttribute("ID")]
        public string ID{get;set;}
        [XmlAttribute("Type")]
        public string Type { get; set; }
        public ResourceCmdParams {get; set;}
    }
