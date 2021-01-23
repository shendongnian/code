    public GenericRepository(ApplicationDbContext _entities)
    {
        entities = _entities;
        _objectSet = entities.Set<T>(); //This line changed.
    }
