    public abstract class GenericDao<TEntity, TDomain, TDbContext> : IGenericDao<TDomain>
        where TDbContext : DbContext, new()
        where TEntity : class
        where TDomain : class
    {
        protected Func<TDbContext> _contextFactory;
    
        public GenericDao(Func<TDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    
        public TDomain Create()
        {
    	using(var context = _contextFactory())
    	{
            	return context.Set<TEntity>().Create();
    	}
        } 
    
        public IList<TDomain> GetAll()
        {
    	using(var context = _contextFactory())
    	{
            	return context.Set<TEntity>().ToList().Select(entity => this.ToDomain(entity)).ToList();
    	}
        }
    
        public void Update(TDomain domain)
        {
    	using(var context = _contextFactory())
    	{
    	        var entity = this.ToEntity(domain);
    		context.Attach(entity);
    	        var entry = this._context.Entry(entity);
    	        entry.State = EntityState.Modified;
    		context.SaveChanges();
    	}
        }
    
        public void Remove(TDomain domain)
        {
    	using(var context = _contextFactory())
    	{
    		var entity = this.ToEntity(domain);
    		context.Attach(entity);
            	context.Set<TEntity>.Remove(entity);
    		context.SaveChanges();
    	}
        }
    
        protected abstract TDomain ToDomain(TEntity entity);
    
        protected abstract TEntity ToEntity(TDomain domain);
    }
