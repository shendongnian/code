        private TEntity _entity = null;
        public DataContext()
            : base()
        {
        }
        public DataContext(TEntity entity)
        {
            this._entity = entity;
        }
        public DbSet<TEntity> Entity { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
        }
        public IConfigurationRoot Configuration { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json");
            Configuration = configuration.Build();
            optionsBuilder.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]);
        }
    }
