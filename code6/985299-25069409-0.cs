       [XmlRoot("rootName")]
        public class ToBeSerialized
        {
            [XmlElement(ElementName = "prop1Here")]
            public string Prop1 { get; set; }
    
            [XmlElement(ElementName = "prop2Here")]
            public int Prop2 { get; set; }
        }
    
        public static void Main()
        {
            var classToSerialze = new ToBeSerialized()
            {
                Prop1 = "prop1value",
                Prop2 = 123
            };
            var xml = SerializeToXML(classToSerialze);
    
        }
    
        public static XElement SerializeToXML<T>(T objectToSerialize)
        {
            using (var memStream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(memStream, objectToSerialize);
                memStream.Flush();
                memStream.Position = 0;
                var xml = XElement.Load(memStream);
                return xml;
            }
        }
