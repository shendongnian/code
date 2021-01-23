    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //  This should include any mappings defined in the same assembly as the BuzzWordMapping class
            modelBuilder.Configurations.AddFromAssembly(typeof(BuzzWordMapping).Assembly);
            base.OnModelCreating(modelBuilder);            
        }
