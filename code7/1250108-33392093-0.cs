	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.Use(async (context, next) =>
			{
				context.Response.OnSendingHeaders(state =>
				{
					((OwinResponse)state).Headers.Remove("Server");
				}, context.Response);
				await next();
			});
            // Configure the rest of your application...
		}
	}
