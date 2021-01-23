    protected static void Update<TEntity>(DbSet<TEntity> set, Expression<Func<TEntity, int>> getParentID, int parentID, List<TEntity> entities, Func<TEntity, int> getID, Action<TEntity, TEntity> updateSingleEntity)
    	where TEntity : class
    {
    	var filter = Expression.Lambda<Func<TEntity, bool>>(Expression.Equal(getParentID.Body, Expression.Constant(parentID)), getParentID.Parameters[0]);
    	var targetEntities = set.Where(filter).ToDictionary(getID);
    	foreach (var entity in entities)
    	{
    		var entityID = getID(entity);
            TEntity targetEntity;
    		if (!targetEntities.TryGetValue(entityID, out targetEntity))
    			set.Add(entity);
    		else
    		{
    			updateSingleEntity(targetEntity, entity);
    			targetEntities.Remove(entityID);
            }
    	}
    	if (targetEntities.Count > 0)
    		set.RemoveRange(targetEntities.Values);
    }
