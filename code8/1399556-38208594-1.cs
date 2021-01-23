    ICollection<string> includes = IncludeVisitor.GetIncludes( query.Expression ); 
    
    foreach (string include in includes)
    {
    	//sometimes the returned include string will be two tables joined with a '.'; these need to be split and each one checked independently
        List<string> split = include.Split( '.' ).ToList();
    
        foreach (string s in split)
        {
            //using .First here because we expect the property to exist
            PropertyInfo prop = contextProperties.First( x => x.Name == s );                    
    
    		//the property will be of type DbSet<ObjectType>, so grab the first generic argument (in this case, the object type)
            Type dbSetPropertyType = prop.PropertyType.GetGenericArguments().First();
    
    		//Get the type we're looking to add in the .Include
            var targetTable = GetTargetTableBasedOnTypeViaNavigation(dbSetPropertyType);                 
    
    		//get the name of the property based on the type of the table we just looked up
            PropertyInfo contextProperty = contextProperties.SingleOrDefault(x => x.PropertyType.IsGenericType && x.PropertyType.GetGenericArguments().First().Name == targetTable.Name );
    
            string includeString = "";                    
    
    		//build the string and add it to the query
            includeString += include + "." + contextPropertyForChangeTracker.Name;
            query = query.Include(includeString);        
        }
    }
