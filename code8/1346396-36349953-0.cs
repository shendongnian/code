    public partial class MyDataContext : DbContext
    {
        public MyDataContext()
            : base("name=MyDataContext")
    
        public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
