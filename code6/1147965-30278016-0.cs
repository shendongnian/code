    [XmlInclude(typeof(Cat))]
    public class Animal
    {
        [XmlIgnore]
        public string Name { get; set; }
        [XmlAnyElement]
        public virtual XElement XmlName
        {
            get
            {
                return Name == null ? null : new XElement("NAME", Name);
            }
            set
            {
                Name = (value == null ? null : value.Value);
            }
        }
    }
    public class Cat : Animal
    {
        // Must be cached as per https://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer%28v=vs.110%29.aspx
        static XmlSerializer nameSerializer;
        static Cat()
        {
            nameSerializer = new XmlSerializer(typeof(NameAndType), new XmlRootAttribute("NAME"));
        }
        [XmlIgnore]
        public NameAndType Name2 { get; set; }
        [XmlAnyElement]
        public override XElement XmlName
        {
            get
            {
                return (Name2 == null ? null : XObjectExtensions.SerializeToXElement(Name2, nameSerializer, true));
            }
            set
            {
                Name2 = (value == null ? null : XObjectExtensions.Deserialize<NameAndType>(value, nameSerializer));
            }
        }
    }
