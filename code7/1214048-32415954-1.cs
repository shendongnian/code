	public class TwitterAuth : IAuthenticate
	{
		bool Login(string user, string pass)
		{
			//connect to twitter api
		}
		
		bool AppliesTo(string providerName)
		{
			// I used the type name for this example, but
			// note that you could use any string or other
			// datatype to select the correct provider.
			return this.GetType().Name.Equals(providerName);
		}
	}
	public class FacebookAuth: IAuthenticate
	{
		bool Login(string user, string pass)
		{
			//connect to fb api
		}
		bool AppliesTo(string providerName)
		{
			return this.GetType().Name.Equals(providerName);
		}
	}
