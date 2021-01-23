	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new TextMap());
		modelBuilder.Configurations.Add(new LanguageMap());
    }
