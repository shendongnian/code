    byte[] bb=new byte[100];
    TcpClient tcpClient = new TcpClient();
    tcpClient.Connect("XXXX",1234) // xxxx is your server ip
    StreamReader sr = new StreamReader(tcpClient.GetStream();
    sr.Read(bb,0,100);
    // to serialize an array and send it to client you can use XmlSerializer
    
    var serializer = new XmlSerializer(typeof(string[]));
        serializer.Serialize(tcpClient.GetStream, someArrayOfStrings);
        tcpClient.Close(); // Add this line otherwise client will keep waiting for server to respond further and will get stuck.
    //to deserialize in client side
    
    
        byte[] bb=new byte[100];
        TcpClient tcpClient = new TcpClient();
        tcpClient.Connect("XXXX",1234) // xxxx is your server ip
    var serializer = new XmlSerializer(typeof(string[]));
     var stringArr = (string[])  serializer.Deserialize(tcpClient.GetStream);
