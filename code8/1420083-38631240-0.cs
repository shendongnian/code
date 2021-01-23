    public class Product
    {
        [XmlAttribute("ID")]
        public string Id { get; set; }
    
        [XmlAttribute("UserTypeID")]
        public string UserTypeId { get; set; }
    
        [XmlArray("Values")]
        [XmlArrayItem("Value", typeof(Value))]
        [XmlArrayItem("MultiValue", typeof(MultiValue))]
        public List<object> Values { get; set; }
    }
    
    public class MultiValue
    {
        [XmlElement(ElementName = "Value")]
        public List<Value> Values { get; set; }
    }
    
    public class Value
    {
        [XmlAttribute("AttributeID")]
        public string AttributeId { get; set; }
    
        [XmlText]
        public string Text { get; set; }
    }
