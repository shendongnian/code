    [XmlRoot("diagnosisList")]
    public class DiagnosisList
    {
        [XmlArray("diagnosis")]
        [XmlArrayItem("surgery")]
        public Surgery[] Diagnosis { get; set; }
    }
    
    [XmlRoot("surgery")]
    public class Surgery
    {
        [XmlElement("date", DataType = "date")]
        public DateTime Date { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("ops301")]
        public string Ops301 { get; set; }
    }
