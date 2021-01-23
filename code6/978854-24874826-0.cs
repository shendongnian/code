    using System.Xml.Serialization; // XML serialization requires this namespace
    using System.IO;
    [XmlRootAttribute("Info")]
    public class Info
    {
        // static constructor will create serializer instance
        static Info()
        {
            Serializer = new XmlSerializer(typeof(Info));
        }        
        // here write constructor based on array of strings
        // this method will serialize current object to stream
        public void SerializeToXml(Stream stream)
        {
            Serializer.Serialize(stream, this);
        }
        // this static method will deserialize object from stream
        public static Info DeserializeFromXml(Stream stream)
        {
            return Serializer.Deserialize(stream) as Info;
        }
        [XmlElement("City")] // use XmlElement, not XmlAttribute
        public string City
        {
            get;
            set;
        }
        // here you can add your other fields like above
        [XmlIgnore] // we want to be sure that this field won't be serialized
        private static XmlSerializer Serializer
        {
            get;
            set;
        }
    }
