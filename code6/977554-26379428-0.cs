     public class DataContext : IdentityDbContext<ApplicationUser>,IDbContext
    {
        public DataContext()
            : base("SurgeryConn")
        {
        }
        public DbSet<Supplier.Supplier> Supplier { get; set; }
        public DbSet<Dispensary.Dispensary> Dispensary { get; set; }
        public DbSet<Biochemistry> Biochemistry { get; set; }
    
      public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
    
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
