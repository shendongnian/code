	public void Add<TEntity, TMapper>() 
		where TEntity : class
		where TMapper : EntityMapper<TEntity>, new()
	{
		this.Entity<TEntity>().Add(new TMapper());
	}
