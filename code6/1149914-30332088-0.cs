    TcpClient client = TcpListener.AcceptTcpClient();
    NetworkStream stream = client.GetStream();
    while (true)
    {
        int bytes = stream.Read(...);
        if (bytes == 0) 
        {
            // other side has disconnected
            stream.Close();
            break;
        }
        // add incoming data to buffer, process messages
        ...
    }
