    public class ArrayOfEndpointInfo
    {
        [XmlElement(ElementName = "EndpointInfo")]
        public EndpointInfo EndPointInfo { get; set; }
    }
    
    public class EndpointInfo
    {
        [XmlArray(ElementName = "PairedEndpoints")]
        public List<PairedEndpoint> PairedEndpoints { get; set; }
    }
    public class PairedEndpoint
    {
        [XmlArrayItem(ElementName="ConnectedChannel")]
        public List<int> ConnectedChannels { get; set; }
    }
