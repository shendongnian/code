    public class ProductsRepository : BaseRepository<Product> // You can have base implementation for basic CRUD operations
    {
         MyDbContext db;
         public ProductsRepository(MyDbContext db)
         {
             this.db = db;
         }
    
         public IQueryable<Product> GetAll()
         {
              return db.Products;
         }
    }
    public class ProductsService : BaseService<Product> // again here....
    {
         ProductsRepository repo;
         public ProductsService()
         {
              repo = new ProductsRepository(new MyDbContext()); // Intentionally not using Dependency Injection here for simplicity....
         }
    
         public List<Product> FilterBy(int[] categoriesIds, decimal minPrice, decimal? maxPrice, string[] colors){
         {
             if (categoriesIds == null)
             {
                 var randomProducts = repo.GetAll().OrderBy(p => Guid.NewGuid());
                 return randomProducts.ToList();
             }
             else
             {
              var filteredProducts = repo.GetAll()
                .Where(p => categoriesIds.Contains(p.CategoryId)
                    && (p.DiscountedPrice >= minPrice
                        && p.DiscountedPrice <= maxPrice || maxPrice == null));
            if (colors != null)
            {
                filteredProducts = filteredProducts
                    .Where(p => colors.Contains(p.Color));
            }
            return filteredProducts.ToList();
        }
    }
