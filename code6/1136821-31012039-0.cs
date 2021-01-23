    public class AspNetDataContext : IdentityDbContext, IDataContext
    {
        private readonly string _connectionString;
        public DbSet<Player> Players { get; set; }
        public AspNetDataContext(DbContextOptions options)
        {
            _connectionString = ((SqlServerOptionsExtension)options.Extensions.First()).ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
