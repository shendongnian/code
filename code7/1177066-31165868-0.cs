    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            modelBuilder.Entity<SomeObject>().Property(m => m.somefield).IsOptional();            
            base.OnModelCreating(modelBuilder);
    }
