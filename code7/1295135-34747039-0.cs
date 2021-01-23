    public IEntity GetEntity<T>(T entity)
        where T : IEntity, new()
    {
        return new T();
    }
