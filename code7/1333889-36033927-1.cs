    public async Task<Entity> AddAsync(Entity entity)
    {
        var savedEntity = m_DataContext.Entities.Add(entity);
        await m_DataContext.SaveChangesAsync();
        return entity.Id;
    }
