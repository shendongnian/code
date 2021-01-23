    public MyEntity GetMyEntity_EagerlyLoad<T>(DbContext context, int id, Expression<Func<MyEntity, T>> loadingProjection, Func<T, MyEntity> resultProjection)
    {
    	var q = context.MyEntities.Where(m => m.ID == id);
    
    	return q.Select(loadingProjection).AsEnumerable().Select(resultProjection).SingleOrDefault();
    }
