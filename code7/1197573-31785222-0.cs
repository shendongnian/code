    frm.debug.Text = "Connecting";
    var client = new TcpClient();
    var result = client.BeginConnect("127.0.0.1", 8001, null, null);
    
    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
    
    if (!success)
    {
        throw new Exception("Failed to connect.");
    }
    
    // we have connected
    frm.debug.Text = "Connected";
    client.EndConnect(result);
