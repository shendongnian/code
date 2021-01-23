    public class DataContext : DbContext
    {
        private readonly ConnectionStringDto _connectionString;
    
        public DataContext(ConnectionStringDto connectionString)
        {
            _connectionString = connectionString;
        }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString.ConnectionString);
        }
        .
        .
        .
