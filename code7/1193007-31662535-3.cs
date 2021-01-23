	public void Apply(EntitySet entitySet, DbModel model)
	{
		Type type = TypeUtils.FindType(entitySet.ElementType.Name);
		if (type != null)
		{
			if (typeof(ILookupValue).IsAssignableFrom(type)) { //make changes here; }
		}
	}
