    	public virtual IServiceProvider ConfigureServices(IServiceCollection services) {
			services.AddMvc();
			services.AddOptions();
			services.AddSession();
			services.AddCaching();
			var assemblyLoadContextAccessor = services.FirstOrDefault(s => s.ServiceType == typeof(IAssemblyLoadContextAccessor)).ImplementationInstance as IAssemblyLoadContextAccessor;
			var libraryManager = services.FirstOrDefault(s => s.ServiceType == typeof(ILibraryManager)).ImplementationInstance as ILibraryManager;
			var loadContext = assemblyLoadContextAccessor.Default;
			foreach(var library in libraryManager.GetLibraries()) {
				var assembly = loadContext.Load(library.Name);
				if(assembly != null) {
					var module = assembly.GetTypes().FirstOrDefault(t => t == typeof(IModule));
					if(module != null)
						ComponentContainer.Builder.RegisterAssemblyModules(assembly);
					else 
						ComponentContainer.RegisterAssembly(assembly);							
				}
			}
			ComponentContainer.Builder.Populate(services);
			return ComponentContainer.ServiceProvider;
		}
