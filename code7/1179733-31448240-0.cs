    public static List<Type> GetAllEntities()
    {
    	var entityList = new List<Type>();
    	var context = typeof(<DatabaseContextClass>);
    	
    	foreach (var property in context.GetProperties())
    	{
    		if (!property.PropertyType.IsGenericType
    			|| property.PropertyType.GetGenericTypeDefinition() != typeof(ObjectSet<>)) // EF 4
    			continue;
    		
    		var entityType = property.PropertyType.GetGenericArguements()[0];
    		entityList.Add(entityType);
    		
    		return entityList;	
    	}
    }
    
    public static T GetFirstObject<T>() where T : EntityObject
    {
    	var context = new <DatabaseContextClass>();
    	
    	IQueryable<T> = dbQuery = context.CreateObjectSet<T>();
    
    	return dbQuery.AQsNoTracking().FirstOrDefault();
    }
