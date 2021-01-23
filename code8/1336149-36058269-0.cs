        public DataContext() : base("DatabaseName")
        {
           // Database.SetInitializer<DataContext>(new DropCreateDatabaseAlways<DataContext>());
            Database.SetInitializer<DataContext>(new CreateDatabaseIfNotExists<DataContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
