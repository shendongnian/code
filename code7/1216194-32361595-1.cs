    public class StoreDb : DbContext, IStoreDataSource
    {
        public StoreDb() : base("GemStoreConnection")
        {
    
        }
    
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    
        void IStoreDataSource.safe()
        {
            SaveChanges();
        }
    
        IQueryable<Product> IStoreDataSource.Products
        {
            get
            {
                return Products;
            }
        }
    
        IQueryable<Category> IStoreDataSource.Categories
        {
            get
            {
                return Categories;
            }
        }
    
        T IStoreDataSource.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }
    
        T IStoreDataSource.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }
    
        T IStoreDataSource.Attach<T>(T entity)
        {
            var entry = Entry(entity);
            entry.State = EntityState.Modified;
            return entity;
        }
    }
