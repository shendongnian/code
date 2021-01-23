    public class MyContext : DbContext 
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Person>() 
                .HasMany<Contact>(p => p.Contacts)
                .WillCascadeOnDelete(true);
        }
    }
