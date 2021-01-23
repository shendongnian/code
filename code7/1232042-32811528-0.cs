    TcpClient client; //Let's say it's already initialized and connected properly
    StreamReader reader = new StreamReader(client.GetStream());
    
    while(client.Connected)
    {
        string message = reader.ReadLine(); //If the string is null, the connection has been lost.
    }
