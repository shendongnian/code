    var all =
    		Assembly
    		.GetEntryAssembly()
    		.GetReferencedAssemblies()
    		.Select(Assembly.Load)
    		.SelectMany(x => x.DefinedTypes)
    		.Where(type => typeof(ICloudProvider).IsAssignableFrom(type.AsType()));
    foreach (var ti in all)
    {
    	var t = ti.AsType();
    	if (!t.Equals(typeof(ICloudProvider)))
    	{
    		// do work
    	}
    }
