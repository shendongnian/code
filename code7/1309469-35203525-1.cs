    public partial class MyModel: DbContext
    {
        public MyModel(): base("name=ConnectionStringName") {}
        public virtual DbSet<A> A { get; set; }
        public virtual DbSet<B> B { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<B>().HasMany(e => e.A).WithOptional(e => e.B).Map(e => e.MapKey("fk_Bld"));
        }
    }
