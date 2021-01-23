    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyConnectionStringName") { }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {    
            modelBuilder.Entity<Person>().HasKey(d => d.Id)
                .HasOptional(m => m.Kid).WithOptionalPrincipal(d=>d.Parent);
    
            base.OnModelCreating(modelBuilder);
        }   
       
        public DbSet<Person> Persons { set; get; }
    }
