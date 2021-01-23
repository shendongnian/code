    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    	modelBuilder.Entity<MyEntity>()
    		.HasRequired(e => e.AnotherEntityInfo)
    		.WithMany()
    		.Map(c => c.MapKey("AnotherEntityInfoId"));
    	base.OnModelCreating(modelBuilder);
    }
