    public class ProductRepository
    {
        private readonly IDbContext _context;
        public ProductRepository(IDbContext dbContext)
        {
            this._context = context;
        }    
        public virtual void Insert(T entity)
        {
            this._context.Products.Add(entity);
        }
    
           // remove some code for brevity
    }
