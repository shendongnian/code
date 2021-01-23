		var repositoryAssembly = typeof(SettingsViewModel).Assembly;
		var registrations =
			from type in repositoryAssembly.GetExportedTypes()
			where type.Namespace == "MyApp.ViewModels"
			where type.GetInterfaces().Any()
			select new { Service = type.GetInterfaces().Single(), Implementation = type };
		foreach (var reg in registrations)
		{
			container.RegisterType(reg.Implementation).As(reg.Service).InstancePerRequest();
		}
