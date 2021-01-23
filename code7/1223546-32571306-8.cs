    [XmlRoot(
        ElementName = "ServiceResources",
        Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class ServiceResources
    {
        public ServiceResources()
        {
            Items = new List<ServiceResource>();
        }
        [XmlElement("ServiceResource")]
        public List<ServiceResource> Items { get; set; }
    }
    public class ServiceResource
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Type")]
        public string Type { get; set; }
        [XmlElement("State")]
        public string State { get; set; }
        [XmlElement("SelfLink")]
        public string SelfLink { get; set; }
        [XmlElement("ParentLink")]
        public string ParentLink { get; set; }
        [XmlElement("StartIPAddress")]
        public string StartIPAddress { get; set; }
        [XmlElement("EndIPAddress")]
        public string EndIPAddress { get; set; }
    }
