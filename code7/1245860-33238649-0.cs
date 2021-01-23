    [Serializable, XmlRoot("BatchChanges, Namespace = "http://www.w3.org/XML/2008/xsdl-exx/ns1") ]
    public class JTDChanges
    {
        [XmlElement("OrgUnitChanges")]
        public List<OrgUnitStage> CustomerChanges = new List<OrgUnitStage>();
    } 
