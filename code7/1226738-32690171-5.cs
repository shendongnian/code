    internal sealed class EntityFrameworkRepository<TEntity> : 
    	IEntityReader<TEntity>, 
    	IEntityWriter<TEntity>, 
    	IUnitOfWork where TEntity : Entity
    {
    	private readonly Func<DbContext> _contextProvider;
    
    	public EntityFrameworkRepository(Func<DbContext> contextProvider)
    	{
    		_contextProvider = contextProvider;
    	}
    
    	public void Create(TEntity entity)
    	{
    		var context = _contextProvider();
    		if (context.Entry(entity).State == EntityState.Detached)
    		{
    			context.Set<TEntity>().Add(entity);
    		}
    	}
    
    	public void Delete(TEntity entity)
    	{
    		var context = _contextProvider();
    		if (context.Entry(entity).State != EntityState.Deleted)
    		{
    			context.Set<TEntity>().Remove(entity);
    		}  
    	}
    
    	public void Update(TEntity entity)
    	{
    		var entry = _contextProvider().Entry(entity);
    		entry.State = EntityState.Modified;
    	}
    
    	public IQueryable<TEntity> Query()
    	{
    		return _contextProvider().Set<TEntity>().AsNoTracking();
    	}
    
    	public TEntity Get(object primaryKey)
    	{
    		return _contextProvider().Set<TEntity>().Find(primaryKey);
    	}
    	
    	public void SaveChanges()
    	{
    		_contextProvider().SaveChanges();
    	}
    }
