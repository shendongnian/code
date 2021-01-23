    public async Task<Entity> GetEntityAsync()
    {
        _entity = await entityManager.GetEntityAsync();
        return _entity
    }
