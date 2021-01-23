    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
        // Skip shadow types
        if (entityType.ClrType == null)
            continue;
        entityType.Relational().TableName = entityType.ClrType.Name;
    }
