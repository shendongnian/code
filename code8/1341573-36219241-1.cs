        [XmlRoot(ElementName = "CheckoutAttributeValue")]
        public class CheckoutAttributeValue
        {
            [XmlElement(ElementName = "Value")]
            public string Value { get; set; }
        }
        [XmlRoot(ElementName = "CheckoutAttribute")]
        public class CheckoutAttribute
        {
            [XmlElement(ElementName = "CheckoutAttributeValue")]
            public CheckoutAttributeValue CheckoutAttributeValue { get; set; }
            [XmlAttribute(AttributeName = "ID")]
            public string ID { get; set; }
        }
        [XmlRoot(ElementName = "Attributes")]
        public class Attributes
        {
            [XmlElement(ElementName = "CheckoutAttribute")]
            public List<CheckoutAttribute> CheckoutAttribute { get; set; }
        }
