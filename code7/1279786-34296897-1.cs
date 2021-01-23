public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
{
	public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
	{
		context.Validated();
	}
	public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
	{
		context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
		if (context.UserName != "Admin")
		{
			context.SetError("upps!", "Wrong data");
			return;
		}
		var identity = new ClaimsIdentity(context.Options.AuthenticationType);
		identity.AddClaim(new Claim("sub", context.UserName));
		identity.AddClaim(new Claim("role", "user"));
		context.Validated(identity);
	}
}
