	listener.Start();
	while(true) {		// beware: please avoid never-ending loop, and define a proper exit condition
		TcpClient client = listener.AcceptTcpClient();
		using(client) {
			Console.WriteLine("Client connected!");
			StreamReader STR = new StreamReader(client.GetStream());
			string s = STR.ReadLine();
			while(s != null) { // read until EOF
    			Console.WriteLine(s);
			}
		}
	}
	listener.Stop();	// this should always be called after exit condition occurs
