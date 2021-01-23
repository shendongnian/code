    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Localizations> Localizations { get; set; }
        private string _connectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _connectionString = ((SqlServerOptionsExtension)optionsBuilder.Options.Extensions.First()).ConnectionString;
            Console.WriteLine($"ApplicationDbContext{_connectionString}");
        }
    public class ApplicationContext : DbContext
    {
        private string _connectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _connectionString = ((SqlServerOptionsExtension)optionsBuilder.Options.Extensions.First()).ConnectionString;
            Console.WriteLine($"ApplicationContext{_connectionString}");
        }
    }
