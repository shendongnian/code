    public void Save(T entity)
    {
        if (entity.ID != 0)
            throw new InvalidOperationException("Attempted to save an entity which has already been saved.");
        Session.Save(entity);
    }
