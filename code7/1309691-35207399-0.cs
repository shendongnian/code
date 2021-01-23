    using (var ctx = new TestContext())
    {
    	var dbSetProperties = ctx.GetDbSetProperties();
    	List<object> dbSets = dbSetProperties.Select(x => x.GetValue(ctx, null)).ToList();
    }
    
    public static class Extensions
    {
    	public static List<PropertyInfo> GetDbSetProperties(this DbContext context)
    	{
    		var dbSetProperties = new List<PropertyInfo>();
    		var properties = context.GetType().GetProperties();
    
    		foreach (var property in properties)
    		{
    			var setType = property.PropertyType;
    
    #if EF5 || EF6
    			var isDbSet = setType.IsGenericType && (typeof (IDbSet<>).IsAssignableFrom(setType.GetGenericTypeDefinition()) || setType.GetInterface(typeof (IDbSet<>).FullName) != null);
    #elif EF7
    			var isDbSet = setType.IsGenericType && (typeof (DbSet<>).IsAssignableFrom(setType.GetGenericTypeDefinition()));
    #endif
    
    			if (isDbSet)
    			{
    				dbSetProperties.Add(property);
    			}
    		}
    
    		return dbSetProperties;
    
    	}
    }
