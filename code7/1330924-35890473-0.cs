    public IEnumerable<TEntity> AddThisRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
    {
      return ((DbSet<TEntity>)this.Set<TEntity>()).AddRange(entities);
    }
    
    
    var Tags = _uow.AddThisRange(newTags.Select(tagName => new Tag
    {
     //set properties
    }));
    
     _uow.SaveAllChanges();
    
    //Pseudocode:
    var savedTags = _uow.GetSavedTags(newTags);
    
    foreach (var tag in savedTags)
    {
       var id = tag.Id;// id will not be 0 anymore
    }
