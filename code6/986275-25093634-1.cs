    public void startClient(TcpClient inClientSocket, string clineNo)
    {
        // ...
        Thread ctThread = new Thread(doChat);
        ctThread.Start();
    }
    private void doChat()
    {
        // ...
        while ((true))
        {
                // ...
                requestCount = requestCount + 1;
                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                Console.WriteLine(" >> " + "From client- " + clNo + dataFromClient);
                // ...
        }
    }
