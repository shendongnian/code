	var task = Task.Factory.StartNew(() =>
	{      
		Console.WriteLine("Starting task...");
		var t = new System.Net.Sockets.TcpClient();
		var buffer = new byte[t.ReceiveBufferSize];
		t.Connect(new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 1337));
		Console.WriteLine("Recieving...");
		t.Client.Receive(buffer);
		Console.WriteLine("Finished Recieving...");
		return true;
    }, cts.Token);
