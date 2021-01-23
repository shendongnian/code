    public class MyContext : DbContext
    {
        private string _connectionString { get; set; }
        public MyContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public MyContext(DbContextOptionsBuilder options) : base(options.Options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (!optionsBuilder.IsConfigured && false == string.IsNullOrEmpty(_connectionString))
            {
                optionsBuilder.UseSqlServer(_connectionString);
                optionsBuilder.UseLoggerFactory(_factory);
            }
            optionsBuilder.UseSqlServer("Data:DefaultConnection:ConnectionString");
        }
    }
