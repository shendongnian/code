    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<MyEntityType>(
            obj =>
            {
                obj.Property<int>(nameof(MyEntityType.ArbitraryPropertyIChoseAsId));
                obj.HasKey(nameof(MyEntityType.ArbitraryPropertyIChoseAsId));
            });
    }
