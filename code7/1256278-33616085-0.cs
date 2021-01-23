    var entitiesInUnitOfWork = typeof(IUnitOfWork).GetProperties()
        .Where(x => 
            x.PropertyType.IsGenericType && 
            x.PropertyType.GetGenericTypeDefinition() == typeof(IQueryable<>) &&  
            typeof(IEntity<Guid>).IsAssignableFrom(x.PropertyType.GetGenericArguments()[0])
        .Distinct();
