    protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
    	base.OnModelCreating(modelBuilder);
    	modelBuilder.Entity<Group>().ToTable("Groups");
    	modelBuilder.Entity<RedGroup>().ToTable("RedGroups");
    	modelBuilder.Entity<GreenGroup>().ToTable("GreenGroups");
    }
