    public class SerializationClass
    {
        [XmlIgnore]
        public string City { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAnyElement]
        public XElement _City
        {
            get { return new XElement("City", new XAttribute("value", City)); }
            set { City = value.FirstAttribute.Value; }
        }
    }
