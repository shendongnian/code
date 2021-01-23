    public class MyContext : DbContext
    {
        private readonly string _prefix;
    
        public MyContext(string prefix)
        {
            _prefix = prefix;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types()
                .Configure(entity => entity.ToTable(_prefix + entity.ClrType.Name));
        }
    
    }
