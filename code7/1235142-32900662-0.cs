    [Serializable()]
    [System.Xml.Serialization.XmlRoot("schools")]
    public class SchoolResponse
    {
       [XmlElement("school")]
       public School[] school { get; set; }
    }
