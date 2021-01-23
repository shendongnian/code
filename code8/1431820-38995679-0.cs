    public class Customer
    {
        [XmlElement(ElementName = "CustomerName")]
        public string Name { get; set; }
    }
    [XmlRoot("XmlCheck")]
    public class XmlCheck
    {
       
        [XmlElement(ElementName = "Customer")]
        public List<Customer> CustomersList { get; set; }
    }
    class Program
    {
        static string xml = @"<?xml version=""1.0"" ?>
    <XmlCheck>
    <Customer>
    <CustomerName>Omer</CustomerName>
    </Customer>
    <Customer>
    <CustomerName>Ali</CustomerName>
    </Customer>
    </XmlCheck>";
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(XmlCheck), new XmlRootAttribute("XmlCheck"));
            using (var stringReader = new StringReader(xml))
            using (var reader = XmlReader.Create(stringReader))
            {
                var xmlResult = (XmlCheck)serializer.Deserialize(reader);
                //xmlResult.CustomersList.Add(xmlResult.Customer);
                foreach(var c in xmlResult.CustomersList)
                {
                    Console.WriteLine(c.Name);
                }
            }
        }
    }
