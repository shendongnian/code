    public class ServiceNinjectModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IMyService>().To<MyServce>();
		}
	}
