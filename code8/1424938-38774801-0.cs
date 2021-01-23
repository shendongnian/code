    Task.Factory.StartNew(() =>
    {
    	Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    	TcpListener tcplistener = new TcpListener(IPAddress.Any, 6000);
    	tcplistener.Start();
    
    
    	TcpClient tcpclient = tcplistener.AcceptTcpClient();
    
    	byte[] data = new byte[1024];
    	NetworkStream ns = tcpclient.GetStream();
    
    	string welcome = "Ola";
    	data = Encoding.ASCII.GetBytes(welcome);
    	ns.Write(data, 0, data.Length);
    
    
    
    });
