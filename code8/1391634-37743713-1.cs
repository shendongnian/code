    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigElement() { Id = 6, Value = "Hello World" };
            var serializer = new XmlSerializer(config.GetType());
    
            serializer.Serialize(File.CreateText("myXml.xml"), config);
        }
    }
