    class Program
    {
        static void Main(string[] args)
        {
            // Create a new file stream for reading the XML file
            FileStream ReadFileStream = new FileStream(@"C:\files\data.xml", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            // Load the object saved above by using the Deserialize function
            Inventory LoadedObj = (Inventory)SerializerObj.Deserialize(ReadFileStream);
            // Cleanup
            ReadFileStream.Close();
            foreach (var node in LoadedObj.Products)
            {
                 // node.Stock = 0;
                //Do what ever changes to stock
            }
            
            XmlSerializer SerializerObj = new XmlSerializer(typeof(Inventory));
            //// Create a new file stream to write the serialized object to a file
            TextWriter WriteFileStream = new StreamWriter(@"C:\files\data.xml");
            SerializerObj.Serialize(WriteFileStream, TestObj);
            //// Cleanup
            WriteFileStream.Close();
           
        }
    }
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRoot("inventory")]
    public class Inventory
    {
        [System.Xml.Serialization.XmlElement("product")]
        public List<Product> Products { get; set; }
      
    }
    [System.SerializableAttribute()]
   
       public class Product
    {
        [System.Xml.Serialization.XmlElementAttribute("recordNumber")]
        public string RecordNumber { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("name")]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("stock")]
        public int Stock { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("price")]
        public int Price { get; set; }
    }
