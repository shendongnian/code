    var configuration = new BusConfiguration();
	configuration.UseSerialization<JsonSerializer>();
	configuration.UseContainer<AutofacBuilder>(x => x.ExistingLifetimeScope(container));
	ConventionsBuilder conventions = configuration.Conventions();
	conventions.DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("Infrastructure.Contract") && t.Namespace.EndsWith("Commands"));
	Bus = NServiceBus.Bus.CreateSendOnly(configuration);
