    ...
	//Start Server
	Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	IPAddress hostIP = (Dns.Resolve(IPAddress.Any.ToString())).AddressList[0];
	IPEndPoint ep = new IPEndPoint(hostIP, port);
	listenSocket.Bind(ep); 
	listenSocket.Listen(backlog);
	//Accept Client
	Socket handler = listener.Accept();
	String data = "Message From Server";
	byte[] msg = Encoding.ASCII.GetBytes(data);
    //Send to Client
	handler.Send(msg);
    ...
