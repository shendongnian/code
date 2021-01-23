	public interface IAuthenticate{
		bool Login(string user, string pass);
		bool AppliesTo(string providerName);
	}
	public interface IAuthenticateStrategy
	{
		bool Login(string providerName, string user, string pass);
	}
