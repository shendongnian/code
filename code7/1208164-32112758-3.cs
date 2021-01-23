    [XmlRoot(ElementName = "ConnectedChannels")]
    public class ConnectedChannels
    {
        [XmlElement(ElementName = "ConnectedChannel")]
        public List<string> ConnectedChannel { get; set; }
    }
    [XmlRoot(ElementName = "PairedEndpoint")]
    public class PairedEndpoint
    {
        [XmlElement(ElementName = "ConnectedChannels")]
        public ConnectedChannels ConnectedChannels { get; set; }
    }
    [XmlRoot(ElementName = "PairedEndpoints")]
    public class PairedEndpoints
    {
        [XmlElement(ElementName = "PairedEndpoint")]
        public List<PairedEndpoint> PairedEndpoint { get; set; }
    }
    [XmlRoot(ElementName = "EndpointInfo")]
    public class EndpointInfo
    {
        [XmlElement(ElementName = "PairedEndpoints")]
        public PairedEndpoints PairedEndpoints { get; set; }
    }
    [XmlRoot(ElementName = "ArrayOfEndpointInfo")]
    public class ArrayOfEndpointInfo
    {
        [XmlElement(ElementName = "EndpointInfo")]
        public EndpointInfo EndpointInfo { get; set; }
    }
