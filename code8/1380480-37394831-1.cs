    private void Form1_Load(object sender, EventArgs e)
    {
        start();
    }
    
    private void start() {
    
        TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 1234);
    
        server.Start();
        
        server.BeginAcceptTcpClient(AcceptClient, server);
    
    }
    
    private void AcceptClient(IAsyncResult result)
    {
        var server = (TcpListener)result.AsyncState;
        TcpClient client = server.EndAcceptTcpClient(result);
        
        Console.WriteLine("Client connected.");
    }
