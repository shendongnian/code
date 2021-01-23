    [XmlRoot(ElementName = "coverageCd")]
    public partial class XmlCoverageCode
    {
        [XmlText]
        public string CoverageCode { get; set; }
    
        [XmlElement("descriptorCd")]
        public List<XmlDescriptor> Descriptors { get; set; }
    }
    
    public partial class XmlDescriptor
    {
        [XmlText]
        public string DescriptorCode { get; set; }
    
        [XmlElement("descriptorCdStartDate")]
        public string DescriptorCodeStartDate { get; set; }
    
        [XmlElement("descriptorCdEndDate")]
        public string DescriptorCodeEndDate { get; set; }
    }
    // ...
    var serializer = new XmlSerializer(typeof(XmlCoverageCode));
    var coverageCode = (XmlCoverageCode)serializer.Deserialize(xmlFileStream);
