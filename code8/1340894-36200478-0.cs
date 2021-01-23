    [XmlRoot(ElementName = "Comp")]
    public class Comp
    {
        [XmlElement(ElementName = "Address")]
        public string Address { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "State")]
        public string State { get; set; }
        [XmlElement(ElementName = "Zipcode")]
        public string Zipcode { get; set; }
        [XmlElement(ElementName = "Rent")]
        public string Rent { get; set; }
        [XmlElement(ElementName = "Dist")]
        public string Dist { get; set; }
    }
    [XmlRoot(ElementName = "Comps")]
    public class Comps
    {
        [XmlElement(ElementName = "Comp")]
        public List<Comp> Comp { get; set; }
    }
    [XmlRoot(ElementName = "rentrangeAPI")]
    public class RentrangeAPI
    {
        [XmlElement(ElementName = "ErrorCode")]
        public string ErrorCode { get; set; }
        [XmlElement(ElementName = "ErrorInfo")]
        public string ErrorInfo { get; set; }
        [XmlElement(ElementName = "Address")]
        public string Address { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "State")]
        public string State { get; set; }
        [XmlElement(ElementName = "Zipcode")]
        public string Zipcode { get; set; }
        [XmlElement(ElementName = "Sqft")]
        public string Sqft { get; set; }
        [XmlElement(ElementName = "Comps")]
        public Comps Comps { get; set; }
    }
