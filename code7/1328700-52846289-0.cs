    public class YourDbContext
    {
        public virtual DbSet<MyChild1> MyChild1s { get; set; }
        public virtual DbSet<MyChild2> MyChild2s { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<MyBase>(); //Ignore base class.
            builder.Entity<MyChild1>(entity =>
            {
                ...
            });
            builder.Entity<MyChild2>(entity =>
            {
                ...
            });
        }
    }
