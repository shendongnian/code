    // In DbContext-inheriting class:
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Ignore the model property that holds my valueobject -
        // (a complex type encapsulating geolocation latitude/longitude)
        var entityBuilder = builder.Entity<Item>()
            .Ignore(n => n.Location);
        
        // Add shadow properties that are appended to the table in the DB
        entityBuilder.Property<string>("Latitude");
        entityBuilder.Property<string>("Longitude");
        base.OnModelCreating(builder);
    }
