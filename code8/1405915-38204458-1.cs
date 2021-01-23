    public MyEntity GetMyEntity_EagerlyLoad(DbContext context, int id, params Expression<Func<MyEntity, object>>[] propertiesToLoad)
    {
    	var q = context.MyEntities.Where(m => m.ID == id);
    
    	foreach (var prop in propertiesToLoad)
    		q = q.Include(prop);
    
    	return q.SingleOrDefault();
    }
