    [XmlRoot(ElementName = "feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class ElementsUsersRoot
    {
        [XmlElement("entry")]
        public List<ElementsUsersData> ElementsUsersDetails { get; set; }
    }
    
    public class ElementsUsersData
    {
        [XmlElement("existing")]
        public bool IsExisting { get; set; }
    
        [XmlElement("object", Namespace = "http://www.sample.com/api")]
        public ElementsUsersAttributes UserAttributes { get; set; }
    }
    
    public class ElementsUsersAttributes
    {
        [XmlElement("first-name")]
        public string Fname { get; set; }
    
        [XmlElement("last-name")]
        public string Lname { get; set; }
    }
