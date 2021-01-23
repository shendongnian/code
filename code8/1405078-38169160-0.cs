    [XmlRoot(Namespace = "http://www.url.com/foo")]
    public class Comprobante
    {
        public string Tags { get; set; }
        public Complemento Complemento { get; set; }
    }
    
    [XmlType(Namespace = "http://www.url.com/foo")]
    public class Complemento
    {
        [XmlElement(Namespace = "http://www.url.com/child")]
        public string Tag { get; set; }
    }
