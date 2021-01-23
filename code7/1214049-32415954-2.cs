	public class AuthenticateStrategy: IAuthenticateStrategy
	{
		private readonly IAuthenticate[] authenticateProviders;
		
		public AuthenticateStrategy(IAuthenticate[] authenticateProviders)
		{
			if (authenticateProviders == null)
				throw new ArgumentNullException("authenticateProviders");
				
			this.authenticateProviders = authenticateProviders;
		}
		public bool Login(string providerName, string user, string pass)
		{
			var provider = this.authenticateProviders
				.FirstOrDefault(x => x.AppliesTo(providerName));
			if (provider == null)
			{
				throw new Exception("Login provider not registered");
			}
			return provider.Login(user, pass);
		}
	}
