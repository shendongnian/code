    private static void HandleClientComm(object client)
    {
        TcpClient tcpClient = (TcpClient)client;
        NetworkStream clientStream = tcpClient.GetStream();
        using(var stream = new StreamReader(clientStream))
        {
           while (stream.Peek() >= 0) 
           {
               Console.WriteLine(server.ReadLine());
           }
        }
    }
