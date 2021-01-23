    [Serializable]
    [XmlRoot("cXML")]
    public class cXML
    {
        [XmlElement("Response")]
        public PResponse PResponse { get; set; } 
    }
    
    [Serializable]
    public class Status
    {
        [XmlAttribute("code")]
        public string Code { get; set; }
        [XmlAttribute("text")]
        public string Text { get; set; }
    }
    [Serializable]
    public class PResponse
    {
        [XmlElement("Status")]
        public Status Status { get; set; }
        [XmlElement("JobID")]
        public string PlanJobID { get; set; }
    }
