     [System.SerializableAttribute()]
    public class SampleClass
    {
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string Foo { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string Bar { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("GivenName", Order = 15)]
        public string[] GivenNames { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[3] { "One", "Two", "Three" };
            SampleClass TestObj = new SampleClass { Bar = "dsdfsdf", Foo = "test", GivenNames = names };
            XmlSerializer SerializerObj = new XmlSerializer(typeof(SampleClass));
            // Create a new file stream to write the serialized object to a file
            TextWriter WriteFileStream = new StreamWriter(@"C:\files\test.xml");
            SerializerObj.Serialize(WriteFileStream, TestObj);
            // Cleanup
            WriteFileStream.Close();
            // Create a new file stream for reading the XML file
            FileStream ReadFileStream = new FileStream(@"C:\files\test.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            // Load the object saved above by using the Deserialize function
            SampleClass LoadedObj = (SampleClass)SerializerObj.Deserialize(ReadFileStream);
            // Cleanup
            ReadFileStream.Close();
        }
    }
