public class Startup
{
	public void Configuration(IAppBuilder app)
	{
		HttpConfiguration config = new HttpConfiguration();
		ConfigureOAuth(app);
		
		WebApiConfig.Register(config);
		app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
		app.UseWebApi(config);
	}
	public void ConfigureOAuth(IAppBuilder app) 
	{
		OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
		{
			AllowInsecureHttp = true,
			TokenEndpointPath = new PathString("/token"),
			AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
			Provider = new SimpleAuthorizationServerProvider()
		};
		// Token Generation
		app.UseOAuthAuthorizationServer(OAuthServerOptions);
		app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
	}
}
