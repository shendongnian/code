    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base()
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.AddBefore<PropertyMaxLengthConvention>(new StringDefaultMaxLengthConvention());
            modelBuilder.Conventions.Add<NameConvention>();
    
            modelBuilder.Entity<Person>();
        }
    }  
  
