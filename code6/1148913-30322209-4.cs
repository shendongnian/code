    public class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Product(string name, decimal price) {
            Name = name;
            Price = price;
        }
        public void TestLog(ISimpleLogger[] loggers) {
            foreach (var item in loggers)
            {
                item.Log("testing...");
            }
        }
    }
