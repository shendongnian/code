	assembly = assemblyLoader.GetAssembly(Program.dllPath);
	if (assembly != null)
	{
		type = assembly.GetType(className);
	}
