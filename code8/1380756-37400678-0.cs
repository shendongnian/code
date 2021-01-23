    public class BaseXmlLoader<TBase> where TBase : Base
    {
        public List<TBase> LoadFromXml(string filePath)
        {
            var serializer = new XmlSerializer(typeof(TBase));
            // Load your file and deserialize.
        }
    }
