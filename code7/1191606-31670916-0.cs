	try
	{
		rep.AutoDetectChangesEnabled(false);
		foreach (var thing in thingsInFile)
		{
			rep.Thing_add(new Thing(thing));
		}
	}
	finally
	{
		rep.AutoDetectChangesEnabled(true);
	}
