    TcpClient client; //Same, it's initialized and connected
    StreamWriter writer = new StreamWriter(client.GetStream());
    writer.AutoFlush = true; //Either this, or you Flush manually every time you send something.
    
    writer.WriteLine("My Message"); //Every message you want to send
