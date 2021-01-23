    public interface IRepository<TEntity> where TEntity : class
    {
    	#region <Methods>
    
    	IQueryable<TEntity> GetActive();
    	IQueryable<TEntity> GetAll();
    	TEntity GetById(object id);
    	TEntity Find(params object[] keyValues);
    	void Add(TEntity entity);
    	void AddRange(IEnumerable<TEntity> entities);
    	void Update(TEntity entity);
    	void Delete(TEntity entity);
    	void Delete(object id);
    	void ApplyState(TEntity entity, EntityState state);
    	EntityState GetState(TEntity entity);
    
    	#endregion
    }
