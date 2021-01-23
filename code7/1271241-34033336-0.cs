	static void Main(string[] args)
	{
		string url = "http://localhost:8080";
		using (WebApp.Start(url))
		{
			Console.WriteLine("Server running on {0}", url);
			// get text to send
			Console.WriteLine("Enter your message:");
			string line = Console.ReadLine();
			
			// Get hub context 
			IHubContext ctx = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
			
			// call addMessage on all clients of context
			ctx.Clients.All.addMessage(message);
			
			// pause to allow clients to receive
			Console.ReadLine();
		}
	}
