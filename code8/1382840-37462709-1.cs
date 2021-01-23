        public Context(DbContextOptions<Context> options)
            : base(options)
        {
             Database.EnsureCreated();
        }
