	public static void RedirectAssembly()
	{
		var list = AppDomain.CurrentDomain.GetAssemblies()
			.Select(a => a.GetName())
			.OrderByDescending(a => a.Name)
			.ThenByDescending(a => a.Version)
			.Select(a => a.FullName)
			.ToList();
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
