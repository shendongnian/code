    [XmlRoot(ElementName = "specVersion", Namespace = "urn:schemas-upnp-org:device-1-0")]
    public class SpecVersion
    {
        [XmlElement(ElementName = "major", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string Major { get; set; }
        [XmlElement(ElementName = "minor", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string Minor { get; set; }
    }
    [XmlRoot(ElementName = "service", Namespace = "urn:schemas-upnp-org:device-1-0")]
    public class Service
    {
        [XmlElement(ElementName = "serviceType", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string ServiceType { get; set; }
        [XmlElement(ElementName = "serviceId", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string ServiceId { get; set; }
        [XmlElement(ElementName = "controlURL", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string ControlURL { get; set; }
        [XmlElement(ElementName = "eventSubURL", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string EventSubURL { get; set; }
        [XmlElement(ElementName = "SCPDURL", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string SCPDURL { get; set; }
    }
    [XmlRoot(ElementName = "serviceList", Namespace = "urn:schemas-upnp-org:device-1-0")]
    public class ServiceList
    {
        [XmlElement(ElementName = "service", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public List<Service> Service { get; set; }
    }
    [XmlRoot(ElementName = "device", Namespace = "urn:schemas-upnp-org:device-1-0")]
    public class Device
    {
        [XmlElement(ElementName = "deviceType", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string DeviceType { get; set; }
        [XmlElement(ElementName = "friendlyName", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string FriendlyName { get; set; }
        [XmlElement(ElementName = "manufacturer", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string Manufacturer { get; set; }
        [XmlElement(ElementName = "manufacturerURL", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string ManufacturerURL { get; set; }
        [XmlElement(ElementName = "modelDescription", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string ModelDescription { get; set; }
        [XmlElement(ElementName = "modelName", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string ModelName { get; set; }
        [XmlElement(ElementName = "modelNumber", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string ModelNumber { get; set; }
        [XmlElement(ElementName = "modelURL", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string ModelURL { get; set; }
        [XmlElement(ElementName = "serialNumber", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string SerialNumber { get; set; }
        [XmlElement(ElementName = "UDN", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string UDN { get; set; }
        [XmlElement(ElementName = "UPC", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string UPC { get; set; }
        [XmlElement(ElementName = "serviceList", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public ServiceList ServiceList { get; set; }
        [XmlElement(ElementName = "deviceList", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public DeviceList DeviceList { get; set; }
    }
    [XmlRoot(ElementName = "deviceList", Namespace = "urn:schemas-upnp-org:device-1-0")]
    public class DeviceList
    {
        [XmlElement(ElementName = "device", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public Device Device { get; set; }
    }
    [XmlRoot(ElementName = "root", Namespace = "urn:schemas-upnp-org:device-1-0")]
    public class Root
    {
        [XmlElement(ElementName = "specVersion", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public SpecVersion SpecVersion { get; set; }
        [XmlElement(ElementName = "URLBase", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public string URLBase { get; set; }
        [XmlElement(ElementName = "device", Namespace = "urn:schemas-upnp-org:device-1-0")]
        public Device Device { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
