      public class TenantDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        private string _connectionString { get; set; }  
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)  
        {
            this._connectionString = "Connection String";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(_connectionString); 
        }
    }
