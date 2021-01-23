    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    	// Ignore all the properties except Id    
    	modelBuilder.ComplexType<EntityInfo>()
    		.Ignore(e => e.Property1)
    		.Ignore(e => e.Property2)
    		...
    		.Ignore(e => e.PropertyN);
    	base.OnModelCreating(modelBuilder);
    }
