    var tcpClient = new TcpClient();
    tcpClient.Connect("192.168.2.20", 3000);
    // set this to a low value to detect cable disconnects early
    tcpClient.Client.KeepAlive(30); // 30 seconds
    Console.WriteLine("Connected..");
    while (true)
    {
        Thread.Sleep(500);
        Console.WriteLine(tcpClient.Client.IsConnected());
    }
