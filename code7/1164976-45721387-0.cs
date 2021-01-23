	public object InitClassFromExternalAssembly(string dllPath, string className)
	{
		try
		{
			Assembly assembly = Assembly.LoadFrom(dllPath);
			Type type = assembly.GetType(className);
			var instance = Activator.CreateInstance(type);
			return instance;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}
