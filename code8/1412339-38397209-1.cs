    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            List<MyModel> myModelsList = context.Products.Include("Names").AsEnumerable().Select(x =>
            {
                MyModel model = new MyModel();
                model.MyList = x.Names.Select(pn => pn.Name).ToList();
                return model;
            }).ToList();
        }
        static void CreateAndSeedDatabase()
        {
            Context context = new Context();
            Product product1 = new Product() { Names = new List<ProductName> { new ProductName { Name = "1" } } };
            Product product2 = new Product() { Names = new List<ProductName> { new ProductName { Name = "2" } } };
            context.Products.Add(product1);
            context.Products.Add(product2);
            context.SaveChanges();
        }
    }
    public class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
            Database.Initialize(true);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductName> ProductNames { get; set; }
    }
    public class Product
    {
        public int ProductId { get; set; }
        public List<ProductName> Names { get; set; }
    }
    public class ProductName
    {
        public int ProductNameId { get; set; }
        public string Name { get; set; }
    }
    public class MyModel
    {
        private List<string> _myList;
        public List<string> MyList
        {
            get { return _myList; }
            set { _myList = value; doSomething(); }
        }
        private void doSomething()
        {
            Console.WriteLine(_myList[0]);
        }
    }
} 
