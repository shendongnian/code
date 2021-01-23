    public partial class ApplicationContext : DbContext, IDbContext
    {
         public ApplicationContext()
             : this("name=ApplicationContext")
        {
        }
        public DbSet<Product> Products { get; set; }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
    }
