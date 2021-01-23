    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<Data>();
            var products = new List<Product>();
            data.Add(new Data { Price = 123.0, Sqft = 456 });
            products.Add(new Product { Name = "SomeProduct" });
            var xEleProperty = new XElement("Property",
                         from item in data
                         from item1 in products
                         select new XElement("Points",
                                      new XElement("Sqft", item.Sqft),
                                      new XElement("Price", item.Price),
                                      new XElement("Product", item1.Name)
                                    ));
            Console.WriteLine(xEleProperty);
            Console.ReadLine();
        }
    }
    public class Data
    {
        public double Price { get; set; }
        public int Sqft { get; set; }
    }
    public class Product
    {
        public string Name { get; set; }
    }
