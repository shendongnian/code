    public static TContext Attach<T, TContext>(this TContext context, T entity)
    		where T : class, IEntity
    		where TContext : DbContext
    {
    	if (entity.IsNew)
    	{
    		context.Set<T>().Add(entity);
    	}
    	else
    	{
    		context.Entry(entity).State = EntityState.Modified;
    	}
    	return context;
    }
  
