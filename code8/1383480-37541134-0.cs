    var timeoutTimer = new Timer(state =>
    {
        var temp = (TcpClient)state;
        Log.Error("Read timeout. Closing connection.");
        temp.Close();
    }, client, Timeout.Infinite, Timeout.Infinite);
