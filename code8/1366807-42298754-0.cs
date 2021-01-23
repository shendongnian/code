	public class SecurityApi : NancyModule
	{
		public SecurityApi()
		{
			Post["api/admin/register", true] = async (_, ct) =>
			{
				var body = this.Bind<RegisterUserBody>();
				var owinContext = new OwinContext(Context.GetOwinEnvironment());
				var userManager = owinContext.GetUserManager<ApplicationUserManager>();
				var user = new User {Id = Guid.NewGuid().ToString(), UserName = body.UserName, Email = body.Email};
				var result = await userManager.CreateAsync(user, body.Password);
				if (!result.Succeeded)
				{
					return this.BadRequest(string.Join(Environment.NewLine, result.Errors));
				}
				return HttpStatusCode.OK;
			};
		}
	}
