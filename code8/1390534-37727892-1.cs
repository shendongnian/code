	public class AStartup
	{
		public void Configuration(IAppBuilder appBuilder)
		{
			HttpConfiguration config = new HttpConfiguration();
			config.Services.Replace(typeof(IAssembliesResolver), new CustomAssemblyResolver(typeof(Controller1).Assembly));
			config.EnsureInitialized();
			appBuilder.UseWebApi(config);
		}
	}
