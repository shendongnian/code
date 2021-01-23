	var filterParametersType = new Dictionary<string, Itype>(1);
	filterParametersType.Add("current", NhibernateUtil.Enum(typeof(ContextType)));
	cfg.AddFilterDefinition(new FilterDefinition("contextFilter", ":current = Context", filterParametersType));
	foreach (var mapping in cfg.ClassMappings)
	{
		if (typeof(IContextAware).IsAssignableFrom(mapping.MappedClass))
		{
			mapping.AddFilter("contextFilter", ":current = Context");
		}
	}
