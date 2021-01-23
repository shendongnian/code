	public class OwinWebRequestScopeAccessor : IScopeAccessor
	{
		void IDisposable.Dispose() { }
		ILifetimeScope IScopeAccessor.GetScope(CreationContext context)
		{
			IOwinContext owinContext = HttpContext.Current.GetOwinContext();
			string key = WebRequestLifestyleMiddleware.EnvironmentKey;
			return owinContext.Environment[key] as ILifetimeScope;
		}
	}
