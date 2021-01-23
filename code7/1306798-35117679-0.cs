    private class StreamParameter
    {
        public TcpClient Client;
        public NetworkStream Stream;
        public byte[] Buffer;
    }
    public void DoBeginAcceptTcpClient(TcpListener listener)
    {
        // Start to listen for connections from a client.
        Console.WriteLine("Waiting for a connection...");
    
        // Accept the connection. 
        // BeginAcceptSocket() creates the accepted socket.
        listener.BeginAcceptTcpClient(DoAcceptTcpClientCallback, listener);
    }
    
    // Process the client connection.
    public void DoAcceptTcpClientCallback(IAsyncResult ar) 
    {
        // Get the listener that handles the client request.
        TcpListener listener = (TcpListener) ar.AsyncState;
    
        // End the operation and display the received data on 
        // the console.
        TcpClient client = listener.EndAcceptTcpClient(ar);
    
        // Start listening for new client right away
        DoBeginAcceptTcpClient(listener);
    
        // Process the connection here
        NetworkStream stream = client.GetStream();
        StreamParameter param = new StreamParamater();
        param.Client = client;
        param.Stream = stream;
        param.Buffer = new byte[512];
        stream.BeginRead(param.Buffer, 0, 512, AsyncReadCallback, param);
    }
    public void AsyncReadCallback(IAsyncResult result)
    {
        StreamParameter param = result.AsyncState as StreamParameter;
        int numBytesRead = param.Stream.EndRead(result);
 
        // Normal processing, sending reply, etc.
    }  
