    public class AppUserManager : UserManager<ApplicationUser>
	{
		public AppUserManager(IServiceProvider services, IHttpContextAccessor contextAccessor, ILogger<UserManager<ApplicationUser>> logger) : base(new UserStore<ApplicationUser>(new ApplicationDbContext()), new CustomOptions(), new PasswordHasher<ApplicationUser>(), new UserValidator<ApplicationUser>[] { new UserValidator<ApplicationUser>() }, new PasswordValidator[] { new PasswordValidator() }, new UpperInvariantLookupNormalizer(), new IdentityErrorDescriber(), services, logger, contextAccessor) 
		{
		}
	}
	public class PasswordValidator : IPasswordValidator<ApplicationUser>
	{
		public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password)
		{
			return Task.Run(() =>
			{
				if (password.Length >= 4) return IdentityResult.Success;
				else { return IdentityResult.Failed(new IdentityError { Code = "SHORTPASSWORD", Description = "Password too short" }); }
			});
		}
	}
	public class CustomOptions : IOptions<IdentityOptions>
	{
		public IdentityOptions Value { get; private set; }
		public CustomOptions()
		{
			Value = new IdentityOptions
			{
				ClaimsIdentity = new ClaimsIdentityOptions(),
				Cookies = new IdentityCookieOptions(),
				Lockout = new LockoutOptions(),
				Password = null,
				User = new UserOptions(),
				SignIn = new SignInOptions(),
				Tokens = new TokenOptions()
			};
		}		
	}
