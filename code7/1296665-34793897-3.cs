    public static class XmlExtensions
    {
        public static XElement ToXElement(this object obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(obj.GetType());
                    xmlSerializer.Serialize(streamWriter, obj);
                    return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var xml = "<Users><UserInfo><Name>Old Name</Name><UserCart></UserCart></UserInfo></Users>";
            var document = XDocument.Parse(xml);
            var userCart = document.Descendants("UserInfo")
                .SingleOrDefault(x => x.Descendants("Name").Single().Value == "Old Name")
                ?.Element("UserCart");
            var newUserCart = new UserCart
            {
                Products = new List<Product>
                {
                    new Product { Name = "First" },
                    new Product { Name = "Second" }
                }
            };
            userCart?.ReplaceWith(newUserCart.ToXElement());
            Console.WriteLine(document.ToString());
        }
    }
    public class UserCart
    {
        public List<Product> Products { get; set; } 
    }
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
