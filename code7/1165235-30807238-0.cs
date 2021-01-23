    public async Task SaveAsyn<T>(T entity) where T : IEntity
    {
        var collection = GetCollection<T>();
        if (entity.Id == null)
        {
            await collection.InsertOneAsync(entity);
        }
        else
        {
            await collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }
    }
