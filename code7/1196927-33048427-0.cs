    public class Product
    {
        public virtual int ProductID { get; set; }
        public virtual string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public virtual decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
    
    [Serializable]
    public sealed class LoggingOnMethodBoundaryAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("Invoking {0} at {1}", args.Method.Name, DateTime.Now.ToLongTimeString());
        }
    }
    
    [TestClass]
    public class UnitTest
    {
    
    
        [TestMethod]
        public void PSharpAopProductShouldHaveAspectsAndBeProduct()
        {
            var product = new Product() { ProductID = 100, ProductName = "a product", UnitPrice = 12.5m };
    
            DisplayProduct(product);
        }
    
        private static void DisplayProduct(Product product)
        {
            Console.WriteLine($"{product.ProductID} - {product.ProductName} - {product.UnitPrice}");
        }
    
    }
