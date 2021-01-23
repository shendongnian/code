    [XmlType("struct")]
    public class ResponseStruct
    {
        [XmlElement("member")]
        public List<ResponseMember> Struct { get; set; }
    }
    [XmlType("array")]
    public class ResponseArray
    {
        [XmlElement("data")]
        public List<ResponseMemberValue> Array { get; set; }
    }
    public class ResponseMember
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("value")]
        public ResponseMemberValue Value { get; set; }
    }
    public class ResponseMemberValue
    {
        [XmlChoiceIdentifier("ValueChoice")]
        [XmlElement("boolean", typeof(bool)), 
        XmlElement("int", typeof(int)), 
        XmlElement("string", typeof(string)), 
        XmlElement("datetime", typeof(DateTime)), 
        XmlElement("double", typeof(double)), 
        XmlElement("base64", typeof(string)), 
        XmlElement(typeof(ResponseArray)), 
        XmlElement(typeof(ResponseStruct))]
        public object Value { get; set; }
        [XmlIgnore]
        public virtual ValueType ValueChoice { get; set; }
        public enum ValueType
        {
            @string,
            @int,
            @datetime,
            @double,
            base64,
            array,
            boolean,
            @struct
        }
    }
