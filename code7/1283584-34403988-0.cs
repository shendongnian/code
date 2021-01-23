    List<SelectItemViewModel<TId> GetAvailableItems<TEntity, TId>(IQueryable<TEntity> entitiesQuery, Func<TEntity, string> getNameForEntity)
      where TEntity : class, IEntity<TId>
    {
      return entitiesQuery
        .AsEnumerable() 
        .Select(e => new SelectItemViewModel<TId>
        {
          Id = e.Id,
          Name = getNameForEntity(e)
        }
    }
