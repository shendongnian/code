    public async Task<IEnumerable<Entity>> GetAllEntitiesFrom(CollectionArgs args)
    {
      var entityType = 
        Type.GetType(
          string.Format(
            "{0}{1}", 
            EntityNamespacePrefix, 
            args.CollectionName), 
          true, 
          true);
      
      var repositoryType =
        typeof(Repository<>)
        .MakeGenericType(entityType);
    
      var repository = 
        (Repository) Activator
        .CreateInstance( repositoryType );
    
      return repository.GetAllAsync();  // await not required
    }
