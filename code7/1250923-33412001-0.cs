    public class Data
    {
        [XmlElement("Hotspot")]
        public List<Hotspot> Hotspot;
    
        [XmlIgnore]
        public Data XmlData;
    
        public void Deserialize()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Data));
            TextReader reader = new StreamReader(@"XMLFile1.xml");
            object obj = deserializer.Deserialize(reader);
    
            XmlData = (Data)obj;
            reader.Close();
        }
    }
    
    public class Hotspot
    {
        [XmlElement("Properties")]
        public List<Properties> Properties = new List<Properties>();
    }
    public class Properties
    {
        public float xPos;
        public float yPos;
    
        [XmlElement("alpha")]
        public float alphaValue;
    }
