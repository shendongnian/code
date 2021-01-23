	public static Type[] GetKnownTypes()
	{
		Type currentType = MethodBase.GetCurrentMethod().DeclaringType;
        return AppDomain.CurrentDomain.GetAssemblies()
                                      .SelectMany(x => x.DefinedTypes)
                                      .Where(x => x.IsSubclassOf(currentType))
                                      .ToArray();
	}
