    void Main()
    {
      var serverTask = Task.Run(() => Server()); // Just to keep this simple and stupid
      
      using (var client = new NamedPipeClientStream(".", "Pipe", PipeDirection.InOut))
      {
        client.Connect();
        client.ReadMode = PipeTransmissionMode.Message;
        
        var buffer = new byte[1024];
        var sb = new StringBuilder();
        
        int read;
        // Reading the stream as usual, but only the first message
        while ((read = client.Read(buffer, 0, buffer.Length)) > 0 && !client.IsMessageComplete)
        {
          sb.Append(Encoding.ASCII.GetString(buffer, 0, read));
        }
        
        Console.WriteLine(sb.ToString());
      }
    }
    
    void Server()
    {
      using (var server
        = new NamedPipeServerStream("Pipe", PipeDirection.InOut, 1, 
                                    PipeTransmissionMode.Message, PipeOptions.Asynchronous)) 
      {
        server.ReadMode = PipeTransmissionMode.Message;      
        server.WaitForConnection();
        
        // On the server side, we need to send it all as one byte[]
        var buffer = Encoding.ASCII.GetBytes(File.ReadAllText(@"D:\Data.txt"));
        server.Write(buffer, 0, buffer.Length); 
      }
    }
