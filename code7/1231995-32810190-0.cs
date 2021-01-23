    while (true)
    {                     
        var tcpClient = tcpListener.AcceptTcpClient();
        var data = new byte[1024];
        var arr1 = new string[] { "one", "two", "three" };
    
        var serializer = new XmlSerializer(typeof(string[]));
        serializer.Serialize(tcpClient.GetStream(), arr1);
    
        var ns = tcpClient.GetStream();
        var recv = ns.Read(data, 0, data.Length); //getting exception in this line
    
        var id = Encoding.ASCII.GetString(data, 0, recv);
    
        Console.WriteLine(id);
    
        tcpClient.Close();
    }       
            
