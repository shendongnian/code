	public class AppBootstrapper : BootstrapperBase
	{
		protected override void Configure()
		{
			...
			_container.Singleton<ISampleService, SampleService>();
			_container.Singleton<SomeUtility>();
			_container.PerRequest<SomeViewModel>();
		}
	}
