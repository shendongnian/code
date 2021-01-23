    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace ConsoleApp4
    {
        [XmlRoot(ElementName = "Sample")]
        public class Sample
        {
            [XmlElement(ElementName = "AccountId")]
            public string AccountId { get; set; }
            [XmlElement(ElementName = "AccountNumber")]
            public string AccountNumber { get; set; }
        }
    
        [XmlRoot(ElementName = "Samples")]
        public class Samples
        {
            [XmlElement(ElementName = "Sample")]
            public List<Sample> Sample { get; set; }
        }
    
        [XmlRoot(ElementName = "Invoice")]
        public class Invoice
        {
            [XmlElement(ElementName = "Samples")]
            public Samples Samples { get; set; }
        }
    }
