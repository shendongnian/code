    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class1>().ToTable("Table1");
            modelBuilder.Entity<Class2>().ToTable("Table2");
            modelBuilder.Entity<Class3>().ToTable("Table3");
           
            base.OnModelCreating(modelBuilder);
        }
