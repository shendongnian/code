	public class WebRequestLifestyleMiddleware : OwinMiddleware
	{
		public const string EnvironmentKey = "WindsorOwinScope";
		public WebRequestLifestyleMiddleware(OwinMiddleware next) : base(next)
		{
		}
		public override async Task Invoke(IOwinContext context)
		{
			ILifetimeScope lifetimeScope = new DefaultLifetimeScope();
			context.Environment[EnvironmentKey] = lifetimeScope;
			try
			{
				await this.Next.Invoke(context);
			}
			finally
			{
				context.Environment.Remove(EnvironmentKey);
				lifetimeScope.Dispose();
			}
		}
	}
