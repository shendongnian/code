    var filteredAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => assFilter.Contains(a.FullName.Split(',')[0]));
    
    	List<Type> allClasses = new List<Type>();
    	foreach (var assembly in filteredAssemblies)
    	{
    		var classArray = assembly.GetTypes().Where(t => t.IsPublic &&
    			!t.IsAbstract &&
    			t.IsClass == true &&
    			classFilter.Contains(t.Namespace));
    		if (classArray != null && classArray.Count() > 0)
    			allClasses.AddRange(classArray);
    	}
