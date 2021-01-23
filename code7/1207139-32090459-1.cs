    public async Task<IEnumerable<Entity>> GetAllEntitiesFrom(CollectionArgs args)
    {
        var entityType = Type.GetType(
            string.Format("{0}{1}", EntityNamespacePrefix, args.CollectionName), true, true);
        var repositoryType = typeof(Repository<>).MakeGenericType(entityType);
        var repository = Activator.CreateInstance(repositoryType);
        var task = (Task)((dynamic)repository).GetAllAsync();
        await task;
        var entities = (IEnumerable<Entity>)((dynamic)task).Result;
        return entities;
    }  
