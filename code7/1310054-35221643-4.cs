    var controllers= myControllerList
    .Where(type =>type.Namespace.StartsWith("X.") &&
        type.GetMethods().Any(m => m.GetCustomAttributes(typeof(MyAttribute)).Any()))
    .SelectMany(type =>
    {
        var actionNames = type.GetMethods().Where(m => m.GetCustomAttributes(typeof(MyAttribute)).Any()).ToList();  
    	return actionNames.Select(action => {
    		var actionName = (MyAttribute)action.GetCustomAttribute(typeof(MyAttribute));
    		return new
    		{
    			 Namespace = GetPath(type.Namespace),
    	    	 ActionName= actionName.Name,
    	    	 Controller = type.Name.Remove(2);		
    		};
    	});    
    }).ToList();
