    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");
    
        foreach (Type type in ...)
        {
            entityMethod.MakeGenericMethod(type)
                .Invoke(modelBuilder, new object[] { });
        }
        base.OnModelCreating(modelBuilder);
    }
