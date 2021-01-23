`
public static class RepositoryExtensions
{
	/// <summary>
	/// A proxy that injects data based on a registered Options type.
	/// As long as we register the Options with exactly what we need, we are good to go.
	/// That's easy, since the Options are non-generic!
	/// </summary>
	private class ProxyRepository<T> : Repository<T>
	{
		public ProxyRepository(Options options, ISubdependency simpleDependency)
			: base(
				// A simple dependency is injected to us automatically - we only need to register it
				simpleDependency,
				// A complex dependency comes through the non-generic, carefully registered Options type
				options?.ComplexSubdependency ?? throw new ArgumentNullException(nameof(options)),
				// Configuration data comes through the Options type as well
				options.ConnectionString)
		{
		}
	}
	public static IServiceCollection AddRepositories(this ServiceCollection services, string connectionString)
	{
		// Register simple subdependencies (to be automatically resolved)
		services.AddSingleton<ISubdependency, Subdependency>();
		// Put all regular configuration on the Options instance
		var optionObject = new Options(services)
		{
			ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString))
		};
		// Register the Options instance
		// On resolution, last-minute, add the complex subdependency to the options as well (with access to the service provider)
		services.AddSingleton(serviceProvider => optionObject.WithSubdependency(ResolveSubdependency(serviceProvider)));
		// Register the open generic type
		// All dependencies will be resolved automatically: the simple dependency, and the Options (holding everything else)
		services.AddSingleton(typeof(IRepository<>), typeof(ProxyRepository<>));
		return services;
		// Local function that resolves the subdependency according to complex logic ;-)
		ISubdependency ResolveSubdependency(IServiceProvider serviceProvider)
		{
			return new Subdependency();
		}
	}
	internal sealed class Options
	{
		internal IServiceCollection Services { get; }
		internal ISubdependency ComplexSubdependency { get; set; }
		internal string ConnectionString { get; set; }
		internal Options(IServiceCollection services)
		{
			this.Services = services ?? throw new ArgumentNullException(nameof(services));
		}
		/// <summary>
		/// Fluently sets the given subdependency, allowing to options object to be mutated and returned as a single expression.
		/// </summary>
		internal Options WithSubdependency(ISubdependency subdependency)
		{
			this.ComplexSubdependency = subdependency ?? throw new ArgumentNullException(nameof(subdependency));
			return this;
		}
	}
}
`
