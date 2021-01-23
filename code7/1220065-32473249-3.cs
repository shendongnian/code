    [Serializable()]
    [System.Xml.Serialization.XmlRoot("root")]
    public class SomeClass
    {
         public Data()
        {
            DataArray = new List<Data>(); 
        }
	
        [XmlElement("data", typeof(Data))]
        public List<Data> DataArray { get; set; }
    } 
    [Serializable()]
    public class Data
    {
        public Data()
        {
            DocumentStatusArray = new List<DocumentStatus>(); 
        }
		
        [XmlElement("item", typeof(DocumentStatus))]
        public List<DocumentStatus> DocumentStatusArray { get; set; }
    } 
	
    [Serializable()]
    public class DocumentStatus
    {
        [System.Xml.Serialization.XmlAttribute("StateId")]
        public int StateId {get; set;}
        [System.Xml.Serialization.XmlAttribute("StateName")]
        public string StateName { get; set; }
        [System.Xml.Serialization.XmlAttribute("GroupId")]
        public GroupId groupId { get; set; } 
    } 
