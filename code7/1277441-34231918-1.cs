    using System.Xml.Serialization;
    ...
    [XmlRoot("root")]
    public class Example {
        [XmlElement("data")]
        public Entries Entries { get; set; }
    }
    public class Entries : List<List<string>>, IXmlSerializable {
        public List<string> Attribs { get; set; }
        public System.Xml.Schema.XmlSchema GetSchema() { return null; }
        public void ReadXml(System.Xml.XmlReader reader) { reader.MoveToContent(); }
        public void WriteXml(System.Xml.XmlWriter writer) {
            foreach (var entry in this) {
                writer.WriteStartElement("entry", "");
                var label = 1;
                foreach (var attrib in entry) {
                    writer.WriteAttributeString(string.Format("Attrib{0}", label), attrib);
                    label++;
                }
                writer.WriteEndElement();
            }
        }
    }
    ...
    var xml = new XmlSerializer(typeof(Example), "");
    xml.Serialize(stream, example);
