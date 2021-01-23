    private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    void init()
    {
        while (!clientSocket.Connected)
        {
            try
            {
                IPAddress ipAd = IPAddress.Parse(IPHERE);
                clientSocket.Connect(ipAd, PORTHERE);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
    }
