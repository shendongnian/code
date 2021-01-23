    data = new byte[1024];
    recv = client.Receive(data);
    string recvconv = Encoding.ASCII.GetString(data, 0, recv);
    
    string name = String.Empty;
    string programmer = String.Empty;
    if (recvconv.StartsWith("name"))
    {
        string[] results = recvconv.Split(':');
        name = results[0];
        programmer = results[1];
    }
    // Do what you need to do with name & programmer
