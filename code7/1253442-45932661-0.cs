    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // every property of type DateTime should have a column type of "datetime2":
        modelBuilder.Property<DateTime>()
          .Configure(property => property.HasColumnType("datetime2");
        // every property of type decimal should have a precision of 19
        // and a scale of 8:
        modelBuilder.Property<decimal>()
            .Configure(property => property.HasPrecision(19, 8);
    }
  
