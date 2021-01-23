    public class SomeClass<T> where T: MyDbContext, new()
    {
        public List<Product> ListAllProducts()
        {
            using(MyDbContext usingDb = new T())
            {
                ((IObjectContextAdapter)usingDb).ObjectContext.CommandTimeout = 120;
                List<Product> products = usingDb.Products.ToList();
                return products;
            }
        }
    }
    // real-code:
    var foo = new SomeClass<MyDbContext>();
    // test
    var bar = new SomeClass<MockContext>();
