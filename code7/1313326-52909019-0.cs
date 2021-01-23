    class ClientListener
    {
        const int PORT_NO = 4500;
        const string SERVER_IP = "127.0.0.1";
        private TcpListener listener;
        public async Task Listen()
        {
            IPAddress localAddress = IPAddress.Parse(SERVER_IP);
            listener = new TcpListener(localAddress, PORT_NO);
            Console.WriteLine("Listening on: " + SERVER_IP + ":" + PORT_NO);
            listener.Start();
            while (true)
            {
                // Accept incoming connection that matches IP / Port number
                // We need some form of security here later
                TcpClient client = await listener.AcceptTcpClientAsync();
                if (client.Connected)
                {
                    // Get the stream of data send by the server and create a buffer of data we can read
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);
                    // Convert the data recieved into a string
                    string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Recieved Data: " + data);
                }
            }
        }
        public void StopListening()
        {
            listener.Stop();
        }
    }
