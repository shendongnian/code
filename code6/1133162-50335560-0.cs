    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("your_connection_string", builder =>
			{
				builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
			});
		base.OnConfiguring(optionsBuilder);
	}
