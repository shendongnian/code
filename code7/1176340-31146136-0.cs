        [XmlRoot("Custom")]
        public class Custom
        {
            [XmlElement("CustomDataType")]
            public CustomDataType customDataType { get; set; }
        }
        [XmlRoot("CustomDataType")]
        public partial class CustomDataType
        {
            [XmlAttribute("AttrField")]
            public string attrField { get; set; }
     
            [XmlAttribute("Value")]]
            public string value {get;set;}
        }
