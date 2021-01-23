    public interface IProduct
    {
        int ProductID { get; set; }
        string ProductName { get; set; }
        decimal? UnitPrice { get; set; }
    }
    
    public class Product : IProduct
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
    
    public class AopProduct : Product
    {
        private readonly IProduct _product;
    
        public override int ProductID { get { return _product.ProductID; } set { _product.ProductID = value; } }
        public override string ProductName { get { return _product.ProductName; } set { _product.ProductName = value; } }
        public override decimal? UnitPrice { get { return _product.UnitPrice; } set { _product.UnitPrice = value; } }
    
        public AopProduct(IProduct product)
        {
            _product = Intercept.ThroughProxy(product, new InterfaceInterceptor(), new IInterceptionBehavior[] { new LoggingInterceptionBehavior() });
        }
    }
    
    public class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("Invoking {0} at {1}", input.MethodBase.Name, DateTime.Now.ToLongTimeString());
            return getNext()(input, getNext);
        }
    
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }
    
        public bool WillExecute => true;
    }
    
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void AopProductShouldHaveAspectsAndBeProduct()
        {
            var product = new Product();
    
            var aopProduct = new AopProduct(product) { ProductID = 100, ProductName = "a product", UnitPrice = 12.5m };
    
            DisplayProduct(aopProduct);
    
            Assert.IsTrue(aopProduct is Product);
        }
    
        private static void DisplayProduct(Product product)
        {
            Console.WriteLine($"{product.ProductID} - {product.ProductName} - {product.UnitPrice}");
        }
    }
