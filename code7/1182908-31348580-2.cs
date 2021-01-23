    public static T GetGenericObject<T>()
    {
        var paramLength = typeof(T).GetConstructors().FirstOrDefault().GetParameters().Length;
    	var parameters = new object[paramLength]; 
       	T resource = (T)Activator.CreateInstance(typeof(T), parameters); 
    	return resource;
    }
