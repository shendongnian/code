    // in a infinite loop
    while (true)
    {
        ...
        // for each TcpClient
        TcpClient tc= serverSocket.AcceptTcpClient();
        // you create a thread!
        System.Threading.Thread obj_thread = new System.Threading.Thread
    }
