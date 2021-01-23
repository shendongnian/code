    private static void HandleClientComm(object client)
    {
        TcpClient tcpClient = (TcpClient)client;
        NetworkStream clientStream = tcpClient.GetStream();
        StreamReader server = new StreamReader(clientStream);
        while (true)
        {
            Console.WriteLine(server.ReadLine());
        }
    }
