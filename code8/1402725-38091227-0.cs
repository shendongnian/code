It is easy. Just use StackTrace.
	var stackTrace = new StackTrace();
	var assemblies = stackTrace.GetFrames().Select(t =>
	{
		var method = t.GetMethod();
		return method.DeclaringType.Assembly;
	});
	foreach (var assembly in assemblies)
	{
		Console.WriteLine(assembly.FullName);
	}
