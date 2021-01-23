        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // If you are letting EntityFrameowrk to create the database, 
            // it will by default create the __MigrationHisotry table in the dbo schema
            // Use HasDefaultSchema to specify alternative (i.e public) schema
            modelBuilder.HasDefaultSchema("public");
        }
