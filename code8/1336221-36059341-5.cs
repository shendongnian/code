    ...
    IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
    IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 11000);
    Socket s = new Socket(endPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
    String data = "Message From Server";
    byte[] msg = Encoding.ASCII.GetBytes(data);
    //Send to Client
    s.SendTo(msg, endPoint);
    ...
