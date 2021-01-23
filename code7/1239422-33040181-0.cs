    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        foreach (var type in builder.GetClrTypes())
        {
            foreach (var property in type.Properties)
            {
                if (property.ClrType == typeof(DateTime))
                {
                    builder.Entity(type.ClrType)
                        .Property(property.ClrType, property.Name)
                        .HasSqlServerColumnType("datetime2(0)");
                }
            }
        }
    }
