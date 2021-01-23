    public class ProductDAL
    {
        private Func<DbContext> _dbFunc;
    
        public ProductDAL(Func<DbContext> dbFunc)
        {
            _dbFunc = dbFunc;
        }
    
        public List<Product> ListAllProducts()
        {
            using(MyDbContext usingDb = _dbFunc())
            {
                // ...
            }
        }
    }
