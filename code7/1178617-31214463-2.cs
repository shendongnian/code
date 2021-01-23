    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<Data>();
            var products = new List<Product>();
    
            data.Add(new Data { ProductId = 1, Price = 321.0, Sqft = 789 });
            products.Add(new Product { Id = 1, Name = "SomeProduct 1" });
    
            data.Add(new Data { ProductId = 2, Price = 123.0, Sqft = 456 });
            products.Add(new Product { Id = 2, Name = "SomeProduct 2" });
    
            var xEleProperty = new XElement("Property",
                         from d in data
                         join product in products on d.ProductId equals product.Id
                         select new XElement("Points",
                                      new XElement("Sqft", d.Sqft),
                                      new XElement("Price", d.Price),
                                      new XElement("Product", product.Name)
                                    ));
            Console.WriteLine(xEleProperty);
            Console.ReadLine();
        }
    }
    
    public class Data
    {
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Sqft { get; set; }
    }
    
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
