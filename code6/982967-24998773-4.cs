    [Serializable]
    [XmlType("record")]
    public class Record
    { 
        [XmlElement("name")]
        public String Name { get; set; }
        [XmlElement("email")]
        public String Email { get; set; }
        [XmlElement("totalpoints")]
        public int TotalPoints { get; set; }
    }
