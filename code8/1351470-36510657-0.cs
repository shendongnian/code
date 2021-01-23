	listener.Start();
	while(true) {		// beware: please avoid never-ending loop, and define a proper exit condition
		TcpClient client = listener.AcceptTcpClient();
		using(client) {
			Console.WriteLine("Client connected!");
			StreamReader STR = new StreamReader(client.GetStream());
			Console.WriteLine(STR.ReadLine());
			// beware: need to add processing for second-line etc, otherwise it will be ignored/discarded
		}
	}
	listener.Stop();	// this should always be called after exit condition occurs
