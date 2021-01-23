        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = BuildConnectionString(); // Your connection string logic here
            optionsBuilder.UseSqlServer(connString);
        }
