    class Program
	{
		static void Main(string[] args)
		{
			var server = new ServerEngine();
			server.Start(IPAddress.Any, 4000);
		}
	}
