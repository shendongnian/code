    protected override void OnModelCreating(DbModelBuilder modelBuilder) 
    {
        //do whatever to get your entity Types
        var entityTypes = typeof(EntitiesLocation).Assembly.GetTypes()
            .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces()
            .Any(i => i == typeof(IEntity)));
        foreach (var entityType in entityTypes)
        {
            GetType().GetMethod(nameof(MapInheritedProperties))
                .MakeGenericMethod(entityType)
                .Invoke(this, new object[] { modelBuilder });
        }
    }
    public void MapInheritedProperties<TEntity>(DbModelBuilder modelBuilder) where TEntity : class
    {
        modelBuilder.Entity<TEntity>().Map(m => m.MapInheritedProperties());
    }
