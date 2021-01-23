    public class DrawnElement {}
    public class Point : DrawnElement {}
    public class Curve : DrawnElement {}
    public class Outline : DrawnElement
    {
        public string WriteToXml()
        {
            // I assume that you have an implementation already for this
            throw new NotImplementedException();
        }
    }
    public class Difficult
    {
        [XmlElement(typeof(DrawnElementSerializationWrapper))]
        public DrawnElement Item;
    }
    public class DrawnElementSerializationWrapper : IXmlSerializable
    {
        private DrawnElement item;
        public DrawnElementSerializationWrapper(DrawnElement item) { this.item = item; }
        public static implicit operator DrawnElementSerializationWrapper(DrawnElement item) { return item != null ? new DrawnElementSerializationWrapper(item) : null; }
        public static implicit operator DrawnElement(DrawnElementSerializationWrapper wrapper) { return wrapper != null ? wrapper.item : null; }
        public System.Xml.Schema.XmlSchema GetSchema()  { return null; }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            // read is not supported unless you also output type information into the xml
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var itemType = this.item.GetType();
            if (itemType == typeof(Outline))    writer.WriteString(((Outline) this.item).WriteToXml());
            else                                new XmlSerializer(itemType).Serialize(writer, this.item);
        }
    }
