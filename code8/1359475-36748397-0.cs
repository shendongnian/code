	public partial class Globals
	{
		// A flag which denotes the environment that the tool should run against (staging/development/production)
		public static string environment;
		public static string server;
		public static void SetEnvironment(string env)
		{
			environment = env;
			switch (env)
			{
				case "development":
					server = "Dev-Server";
					break;
				case "staging":
					server = "Staging-Server";
					break;
				case "production":
					server = "Production-Server";
					break;
				default:
					server = "Dev-Server";
					break;
			}
		}
	}
