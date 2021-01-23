    void Main()
    {
    	Console.WriteLine("Starting listener thread");
    	Thread serverThread = new Thread(ListenerThreadProc);
    	serverThread.Start();
    	
    	Console.WriteLine("Waiting 500 milliseconds to allow listener to start");
    	Thread.Sleep(500);
    	
    	Console.WriteLine("Client: Connecting to server");
    	TcpClient client = new TcpClient();
    	client.Connect(IPAddress.Loopback, 12345);
    	Console.WriteLine("Client: Connected to server");
    	
    	byte[] buffer = new byte[5];
    	Console.WriteLine("Client: Receiving data");
    	using (NetworkStream clientStream = client.GetStream())
    		clientStream.Read(buffer, 0, buffer.Length);
    		
    	Console.WriteLine("Client: Received data: " + buffer.Aggregate("", (s, b) => s += " " + b.ToString()));		
    }
    
    void ListenerThreadProc()
    {	
    	TcpListener listener = new TcpListener(IPAddress.Any, 12345);
    	listener.Start();
    	Console.WriteLine("Server: Listener started");
    	
    	Console.WriteLine("Server: Waiting for client to connect");
    	TcpClient client = listener.AcceptTcpClient();
    	Console.WriteLine("Server: Client connected");
    	
    	listener.Stop();	
    	Console.WriteLine("Server: Listener stopped");
    	
    	Console.WriteLine("Server: Sending data");
    	byte[] buffer = new byte[] { 1, 2, 3, 4, 5 };	
    	using (NetworkStream clientStream = client.GetStream())
    		clientStream.Write(buffer, 0, buffer.Length);
    	Console.WriteLine("Server: Sent data");
    }
