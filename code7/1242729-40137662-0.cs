    public class ProductService : IProductService
    {
        private IProductContext _dbCreator;
        public ProductService(Func<IProductContext> dbCreator)
        {
            _db = db;
        }
        public List<Product> GetProductsByCategory(string cleanCategory)
        {
            using (var dbCtx = _dbCreator())
            {
                return dbCtx.Products
                     .Include(p => p.Options.Select(o => o.OptionGroup))
                         .Include(p => p.Associations.Select(a => a.AssociatedGroup))
                         .Include(p => p.Variations).Include(p => p.Manufacturer)
                         .Where(p => p.Active && p.Category.Name.ToUpper().Equals(cleanCategory)).ToList();
            }
        }
        .....
    }
