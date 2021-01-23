    var types = (typeof(ClassinAssembly).Assembly)
												.GetTypes()
												.Where(x => typeof(IMyInterface).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
												.ToList();
	foreach (var t in types)
	{
      .....
    }
