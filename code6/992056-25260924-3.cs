    Console.WriteLine("Starting: Creating Socket object");
    Socket listener = new Socket(AddressFamily.InterNetwork,
    SocketType.Stream,
    ProtocolType.Tcp);
    listener.Bind(new IPEndPoint(IPAddress.Any, 2112));
    listener.Listen(10);
    while (true)
    {
      Console.WriteLine("Waiting for connection on port 2112");
      Socket socket = listener.Accept();
      string receivedValue = string.Empty;
      while (true)
      {
        if (socket.Available > 0)
        {
          do
          {
            var receivedBytes = new byte[socket.Available];
            socket.Receive(receivedBytes);
            Console.WriteLine("Receiving...");
            receivedValue += Encoding.Default.GetString(receivedBytes);
          } while (socket.Available > 0);
          break;
        }
      }
      Console.WriteLine("Received value: {0}", receivedValue);
      Console.WriteLine("Enter ur Msg");
      string replyValue = Console.ReadLine();
      //string replyValue = "Message successfully received.";
      byte[] replyMessage = Encoding.Default.GetBytes(replyValue);
      socket.Send(replyMessage);
      socket.Shutdown(SocketShutdown.Both);
      socket.Close();
    }
    listener.Close();
