    async void ButtonConnectOnClick(object obj, EventArgs ea)
    {
    tcpListener = new TcpListener(IPAddress.Any, 1234);
    tcpListener.Start();
    newText.Text = "Server started"; //**This line is not working**
      await Task.Run(() =>
       {
    //Infinite loop to connect to new clients      
    while (true)
    {
        // Accept a TcpClient      
        TcpClient tcpClient = tcpListener.AcceptTcpClient();
        string address = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                   byte[] data = new byte[1024];
        NetworkStream ns = tcpClient.GetStream();
        int recv = ns.Read(data, 0, data.Length);
                    StreamReader reader = new StreamReader(tcpClient.GetStream());
        // The first message from the client is the file size      
        string cmdFileSize = reader.ReadLine();
        int length = Convert.ToInt32(cmdFileSize);
        byte[] buffer = new byte[length];
        int received = 0;
        int read = 0;
        int size = 1024;
        int remaining = 0;
        // Read bytes from the client using the length sent from the client      
        while (received < length)
        {
            remaining = length - received;
            if (remaining < size)
            {
                size = remaining;
            }
            read = tcpClient.GetStream().Read(buffer, received, size);
            received += read;
        }
         }
     });
    }
