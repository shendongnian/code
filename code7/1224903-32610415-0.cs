	public class Startup
	{
		public void Configuration(IAppBuilder appBuilder)
		{
			//.....
            //This must be registered first
			appBuilder.Use(typeof(LoggingMiddleware));
            //Register this last
			appBuilder.UseWebApi(config);
		}
	}
