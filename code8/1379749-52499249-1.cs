    protected override void OnModelCreating(ModelBuilder builder)
    {
        var splitStringConverter = new ValueConverter<IEnumerable<string>, string>(v => string.Join(";", v), v => v.Split(new[] { ';' }));
        builder.Entity<Entity>().Property(nameof(Entity.SomeListOfValues)).HasConversion(splitStringConverter);
    } 
