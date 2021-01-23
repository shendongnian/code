    public class CoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Organization> Organization { get; set; }
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Individual>();
            builder.Entity<Company>();
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
