	public class AppBootstrapper : BootstrapperBase
	{
		protected override void Configure()
		{
			...
			_container.Handler<IScreen>((x) => x.GetInstance<SomeViewModel>());
		}
	}
