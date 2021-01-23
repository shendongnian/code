	public static void RegisterNewClass<T>(T theObject)
	{
		...
		if (!lvl3Found)
		{
			try
			{
				lvl3Map.SetDiscriminator(lvl3Type.Name);
				BsonClassMap.RegisterClassMap(lvl3Map);
				lvl4Map.AddKnownType(lvl3Type);
			}
			catch (Exception e)
			{
				Console.WriteLine("Level 3 adding went wrong!");
				Console.WriteLine(e.Message);
			}
		}
		...
	}
