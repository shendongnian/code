    public TEntity Create<TEntity>()
    {
       return ((DbSet<TEntity>)this.Set<TEntity>()).Create();
    }
    
    var listOfEntities =new List<Tag>();
    foreach (var d in newTags)
    {
        var entity = Create<Tag>();
        //set properties        
        //entity.prop=""
    }
    _uow.AddThisRange(listOfEntities);
    _uow.SaveAllChanges();
    
