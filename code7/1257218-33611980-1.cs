    [XmlRoot(ElementName = "RootElement")]
    public class RootElement
    {
        [XmlElement(ElementName = "iRootElementId")]
        public string IRootElementId { get; set; }
        [XmlElement(ElementName = "sRootElementName")]
        public string SRootElementName { get; set; }
        [XmlElement(ElementName = "sRootElementDescription")]
        public string SRootElementDescription { get; set; }
        [XmlArrayItem(ElementName = "Folder")]
        public List<Folder> Folders { get; set; }
    }
