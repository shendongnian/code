    var assembly = Assembly.LoadFile("C:\path_to_your_exe\YourExe.exe");
    
    foreach (var type in assembly.GetTypes())
	{
		Console.WriteLine($"Class {type.Name}:");
		Console.WriteLine($"  Namespace: {type.Namespace}");
		Console.WriteLine($"  Full name: {type.FullName}");
		Console.WriteLine($"  Methods:");
		foreach (var methodInfo in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
		{
			Console.WriteLine($"    Method {methodInfo.Name}");
			if (methodInfo.IsPublic)
				Console.WriteLine($"      Public");
			if (methodInfo.IsFamily)
				Console.WriteLine($"      Protected");
			if (methodInfo.IsAssembly)
				Console.WriteLine($"      Internal");
			if (methodInfo.IsPrivate)
				Console.WriteLine($"      Private");
			Console.WriteLine($"      ReturnType {methodInfo.ReturnType}");
			Console.WriteLine($"      Arguments {string.Join(", ", methodInfo.GetParameters().Select(x => x.ParameterType))}");
		}
	}
