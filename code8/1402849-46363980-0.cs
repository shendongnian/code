    public static void RedirectAssembly()
	{
		var list = AppDomain.CurrentDomain.GetAssemblies().OrderByDescending(a => a.FullName).Select(a => a.FullName).ToList();
		AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
		{
			var requestedAssembly = new AssemblyName(args.Name);
			foreach (string asmName in list)
			{
				if (asmName.StartsWith(requestedAssembly.Name + ","))
				{
					return Assembly.Load(asmName);
				}
			}
			return null;
		};
	}
