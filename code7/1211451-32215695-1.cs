    public class node
    {
        public int id;
        public string nodeName;
        [System.Xml.Serialization.XmlElement("node")] // This is missing from your class definition
        public List<node> children;
    }
    public class root
    {
        public node node { get; set; }
    }
    public static class XmlSerializationHelper
    {
        public static T LoadFromXML<T>(this string xmlString)
        {
            using (StringReader reader = new StringReader(xmlString))
            {
                object result = new XmlSerializer(typeof(T)).Deserialize(reader);
                if (result is T)
                {
                    return (T)result;
                }
            }
            return default(T);
        }
    }
