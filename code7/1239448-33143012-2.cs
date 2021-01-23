    TcpClient tcpClient = new TcpClient(host, port);
    NetworkStream netStream = tcpClient.GetStream();
    StreamReader reader = new StreamReader(netStream);
    
    string message;
    bool running = true;
    while(running)
    {
        message = reader.ReadLine();
        if(message.Equals("yes"))
        {
            Command command = Serializer.DeserializeWithLengthPrefix<Command>(netStream, PrexiStyle.Base128);
            BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create));
            bw.Write(command.File);
        }
    }
    bw.Flush();
    bw.Close();
