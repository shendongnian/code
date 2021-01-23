    namespace DataLibrary
    {
        public class AppContext : IdentityDbContext<ApplicationUser>
        {
            public DbSet<tbl_Person> tbl_Person { get; set; }
            protected override void OnModelCreating(ModelBuilder builder)
            {
                new tbl_PersonMap(builder.Entity<tbl_Person>());
                base.OnModelCreating(builder);
            }
        }
    }
