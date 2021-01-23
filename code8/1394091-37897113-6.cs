    public partial class MyEntities : DbContext
    {
        public MyEntities ()
            : base("name=MyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<MyTable> MyTable { get; set; }
    }
