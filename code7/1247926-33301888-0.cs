    public static class Utils
    {
    	public static string GetName<T>(this DbContext db, int id)
    		where T : class
    	{
    		var source = Expression.Parameter(typeof(T), "source");
    		var idFilter = Expression.Lambda<Func<T, bool>>(
    			Expression.Equal(Expression.Property(source, "id"), Expression.Constant(id)),
    			source);
    		var nameSelector = Expression.Lambda<Func<T, string>>(
    			Expression.Property(source, "Name"),
    			source);
    		return db.Set<T>().Where(idFilter).Select(nameSelector).FirstOrDefault();
    	}
    }
