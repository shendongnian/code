	public partial class Startup
	{
		private static string _aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
		private static string _tenant = ConfigurationManager.AppSettings["ida:Tenant"];
		private static string _realm = ConfigurationManager.AppSettings["ida:Wtrealm"];
		private static string _metadataAddress = string.Format("{0}/{1}/federationmetadata/2007-06/federationmetadata.xml", _aadInstance, _tenant);
		private static string _authority = String.Format(CultureInfo.InvariantCulture, _aadInstance, _tenant);
		public void ConfigureAuth(IAppBuilder app)
		{
			app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
			app.UseCookieAuthentication(new CookieAuthenticationOptions());
			app.UseWsFederationAuthentication(
				new WsFederationAuthenticationOptions
				{
					Wtrealm = _realm,
					MetadataAddress = _metadataAddress,
					TokenValidationParameters = new TokenValidationParameters
					{
						ValidAudiences = new string[] { "spn:" + _realm }
					}
				}
			);
		}
	}
	
