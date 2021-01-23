    public class PropertyClass<T>
    {
        public List<T> Settings { get; set; }
        public PropertyClass()
        {
            Settings = new List<T>();
        }
        public void SaveXml(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("Settings"));
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);
                XML.Serialize(stream, Settings, namespaces);
            }
        }
    }
