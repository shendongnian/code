	public class MyAuthHandler : AuthenticationHandler<MyAuthOptions>
	{
	   protected override Task<AuthenticationTicket> HandleAuthenticateAsync()
	   {
		  // grab stuff from the HttpContext
		  string authHeader = Request.Headers["Authorization"] ?? "";
		  string path = Request.Path.ToString() ?? "";
		  // make a MyAuth identity with claims specifying what we'll validate against
		  var identity = new ClaimsIdentity(new[] {
			 new Claim(ClaimTypes.Authentication, authHeader),
			 new Claim(ClaimTypes.Uri, path)
		  }, Options.AuthenticationScheme);
		  var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), 
			 new AuthenticationProperties(), Options.AuthenticationScheme);
		  return Task.FromResult(ticket);
	   }
	}
	public class MyAuthOptions : AuthenticationOptions
	{
	   public const string Scheme = "MyAuth";
	   public MyAuthOptions()
	   {
		  AuthenticationScheme = Scheme;
		  AutomaticAuthentication = true;
	   }
	}
	public class MyAuthMiddleware : AuthenticationMiddleware<MyAuthOptions>
	{
	   public MyAuthMiddleware(
				   RequestDelegate next,
				   IDataProtectionProvider dataProtectionProvider,
				   ILoggerFactory loggerFactory,
				   IUrlEncoder urlEncoder,
				   IOptions<MyAuthOptions> options,
				   ConfigureOptions<MyAuthOptions> configureOptions)
			 : base(next, options, loggerFactory, urlEncoder, configureOptions)
	   {
	   }
	   protected override AuthenticationHandler<MyAuthOptions> CreateHandler()
	   {
		  return new MyAuthHandler();
	   }
	}
	public static class MyAuthMiddlewareAppBuilderExtensions
	{
	   public static IApplicationBuilder UseMyAuthAuthentication(this IApplicationBuilder app, string optionsName = "")
	   {
		  return app.UseMiddleware<MyAuthMiddleware>(
			 new ConfigureOptions<MyAuthOptions>(o => new MyAuthOptions()) { Name = optionsName });
	   }
	}
