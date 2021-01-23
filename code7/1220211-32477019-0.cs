    IEnumerable<T> result = _entityRepo.All();
    bool isEntityType = typeof(Entity).IsAssignableFrom(typeof(T));
    if (isEntityType)
    {
        result = result.Where(x => ((Entity)x).IsDeleted == true);
    }
    return result;
