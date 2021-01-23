    // The Collection<MyProperty> base class is responsible for maintaining the list
    public class MyPropertyCollection : Collection<MyProperty>
    {
        public MyPropertyCollection()
        {
            // Default base() constructor is called automatically
        }
        public MyPropertyCollection(IList<MyProperty> properties)
            : base(properties)
        {
             // Overloaded constructor calls base constructor with collection of properties
        }
        public void SaveXml(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                // Serializer should now target this very class
                var xml = new XmlSerializer(typeof (this), new XmlRootAttribute("Settings"));
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);
                xml.Serialize(stream, this, namespaces);
            }
        }
    }
