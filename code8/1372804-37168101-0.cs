    public class XmlType
    {
        [XmlElement("derived", IsNullable = true)]
        public DerivedTypeXml derivedType { get; set; }
        // No need [XmlIgnore]
        public string Type { get; set; }
    }
