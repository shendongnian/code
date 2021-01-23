    protected override void OnModelCreating(ModelBuilder builder) 
    {
        foreach (var type in builder.Model.EntityTypes.Where(type => type.HasClrType))
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
