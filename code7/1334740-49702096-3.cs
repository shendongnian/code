    public partial class LocalDBContext : DbContext
    { 
        public LocalDBContext(DbContextOptions<LocalDBContext> options) : base(options)
        {
    
        }
     
        public virtual DbSet<YourView> YourView { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YourView>(entity => {
                entity.HasKey(e => e.ID);
                entity.ToTable("YourView");
                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    
    }
    
