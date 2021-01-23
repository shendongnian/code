		var repositoryAssembly = typeof(SettingsViewModel).Assembly;
		var registrations =
			from type in repositoryAssembly.GetExportedTypes()
			where type.Namespace == "MyApp.ViewModel"
			where type.GetInterfaces().Any()
			select new { Service = type.GetInterfaces().Single(), Implementation = type };
		foreach (var reg in registrations)
		{
			container.RegisterType(reg.Implementation).As(reg.Service).InstancePerRequest();
		}
