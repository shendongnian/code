    [XmlRoot("data")]
    public class Data
    {
        [XmlArray("audit_values")]
        [XmlArrayItem("audit_value", IsNullable = true)]
        public AuditValue[] AuditValues { get; set; }
    }
    public class AuditValue
    {
        [XmlElement("week")]
        public Week Week;
    }
    public class Week : IXmlSerializable
    {
        public Dictionary<string, double> Values = new Dictionary<string, double>();
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            Values = XElement.Parse(reader.ReadOuterXml())
                .Elements()
                .ToDictionary(k => k.Name.ToString(), v => double.Parse(v.Value));
        }
        public void WriteXml(XmlWriter writer)
        {
        }
    }
