    public static List<System.Type> GetAllDerivedTypes<T>(Assembly primaryAssembly, bool bAcceptAbstract = true) where T : class
    {
        if (primaryAssembly == null)
            throw new ArgumentNullException("The primary assembly is unassigned.");
			
		return !bAcceptAbstract ? primaryAssembly.GetTypes().Where(type => typeof(T).IsAssignableFrom(type) && !type.IsAbstract).ToList() : primaryAssembly.GetTypes().Where(type => typeof(T).IsAssignableFrom(type)).ToList();
    }
