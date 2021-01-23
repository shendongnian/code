    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CodeFirstContext>());            
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
              .HasRequired(co => co.Contact)
              .WithOptional(cu => cu.ContactUser);
            base.OnModelCreating(modelBuilder);
        }
    }
