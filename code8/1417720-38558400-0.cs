        class MyContext : DbContext
        {
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MyContext>(modelBuilder);
                Database.SetInitializer(sqliteConnectionInitializer);
            }
            public DbSet<Person> Persons { get; set; }
        }
