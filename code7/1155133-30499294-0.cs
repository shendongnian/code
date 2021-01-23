    public class MyPathClass
    {
        [XmlAttribute]
        public bool IsActive { get; set; }
    
        [XmlText]
        public string Value { get; set; }
    
        public static implicit operator string(MyPathClass value)
        {
            return value.Value;
        }
    
        public static implicit operator MyPathClass(string value)
        {
            return new MyPathClass { Value = value };
        }
    }
    
    public class MySerializeableClass
    {
        [XmlElement]
        public MyPathClass AnyPath { get;set; }
    }
