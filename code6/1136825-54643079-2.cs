    public class MyContext : DbContext
    {
        private string _connectionString { get; set; }
        public MyContext(string connectionString) //Inject external connectionstring.
        {
            _connectionString = connectionString;
        }
        public MyContext(DbContextOptionsBuilder options) : base(options.Options) //Default binding from web.config.
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (!optionsBuilder.IsConfigured && false == string.IsNullOrEmpty(_connectionString)) // if no default binding
            {
                optionsBuilder.UseSqlServer(_connectionString); //Use provider as SQL server and make connection through connection string.
                optionsBuilder.UseLoggerFactory(_factory);//optional, Use Logger factory
            }
            base.OnConfiguring(optionsBuilder); //configure connection
        }
    }
