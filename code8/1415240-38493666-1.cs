	Scan(_ =>
	{
		// Declare which assemblies to scan
		// In this case, I am assuming that all of your custom
		// filters are in the same assembly as the GlobalFilterProvider.
		// So, you need to adjust this if necessary.
		_.AssemblyContainingType<GlobalFilterProvider>();
		// Optional: Filter out specific MVC filter types
		_.Exclude(type => type.Name.EndsWith("Controller"));
		// Add all filter types.
		_.AddAllTypesOf<IActionFilter>();
		_.AddAllTypesOf<IAuthorizationFilter>();
		_.AddAllTypesOf<IExceptionFilter>();
		_.AddAllTypesOf<IResultFilter>();
		_.AddAllTypesOf<IAuthenticationFilter>(); // MVC 5 only
	});
