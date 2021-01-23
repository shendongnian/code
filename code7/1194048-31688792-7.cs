	public class MyAuthHandler : AuthenticationHandler<MyAuthOptions>
	{
	   protected override async Task<AuthenticationTicket> HandleAuthenticateAsync()
	   {
		  await Task.Run(() =>
		  {
			 // grab stuff from the HttpContext
			 string authHeader = Request.Headers["Authorization"] ?? "";
			 string path = Request.Path.ToString() ?? "";
			 // add an identity to the user that specifies what 
			 // we'll validate against for our authentication type
			 Claim[] claims =
			 {
				new Claim(ClaimTypes.Authentication, authHeader),
				new Claim(ClaimTypes.Uri, path)
			 };
			 var identity = new ClaimsIdentity(claims, Options.AuthenticationScheme);
			 Context.User.AddIdentity(identity);
		  });
		  var properties = new AuthenticationProperties();
		  return new AuthenticationTicket(Context.User, properties, Options.AuthenticationScheme);
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
