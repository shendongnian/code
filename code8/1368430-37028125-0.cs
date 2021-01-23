	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
        // ...
		modelBuilder.Entity<someEntity>()
			.Property(p => p.ChangedOn)
			.HasColumnType("datetime2");
        // ...
	}
