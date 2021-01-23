    using System.Xml.Linq;
    using System.Xml.Serialization;
    public class XMLHelper
    {
        public T DeserializeData<T>(string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(data);
            var deserializedObject = serializer.Deserialize(reader);
            return deserializedObject == null ? default(T) : (T)deserializedObject;
        }
    }
