    [XmlRoot(ElementName = "currency")]
    public class Currency
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "iso_code")]
        public string Iso_code { get; set; }
        [XmlElement(ElementName = "iso_code_num")]
        public string Iso_code_num { get; set; }
        [XmlElement(ElementName = "blank")]
        public string Blank { get; set; }
        [XmlElement(ElementName = "sign")]
        public string Sign { get; set; }
        [XmlElement(ElementName = "format")]
        public string Format { get; set; }
        [XmlElement(ElementName = "decimals")]
        public string Decimals { get; set; }
        [XmlElement(ElementName = "conversion_rate")]
        public string Conversion_rate { get; set; }
        [XmlElement(ElementName = "deleted")]
        public string Deleted { get; set; }
        [XmlElement(ElementName = "active")]
        public string Active { get; set; }
    }
    [XmlRoot(ElementName = "prestashop")]
    public class Prestashop
    {
        [XmlElement(ElementName = "currency")]
        public Currency Currency { get; set; }
        [XmlAttribute(AttributeName = "xlink", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xlink { get; set; }
    }
