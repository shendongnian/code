	var currentAssembly = typeof(SomeLocalType).Assembly;
	var interfaceAssemblies = new Assembly[] { 
		currentAssembly 
		/*, Additional Assemblies */ 
		};
	var implementationAssemblies = new Assembly[] { 
		currentAssembly 
		/*, Additional Assemblies */ 
		};
	var excludeTypes = new Type[]
	{
		// Use this array to add types you wish to explicitly exclude from convention-based  
		// auto-registration. By default all types that either match I[TypeName] = [TypeName] 
		// will be automatically wired up.
		//
		// If you want to override a type that follows the convention, you should add the name 
		// of either the implementation name or the interface that it inherits to this list and 
		// add your manual registration code below. This will prevent duplicate registrations 
		// of the types from occurring. 
		// Example:
		// typeof(SiteMap),
		// typeof(SiteMapNodeVisibilityProviderStrategy)
	};
    var scopedLifestyle = new WebApiRequestLifestyle();
	CommonConventions.RegisterDefaultConventions(
		// This registers with a SimpleInjector container
		(interfaceType, implementationType) => 
            container.Register(interfaceType, implementationType, scopedLifestyle),
		interfaceAssemblies,
		implementationAssemblies,
		excludeTypes,
		string.Empty);
