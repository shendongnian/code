    while (socket.Available > 0)
    {
      byte[] receivedBytes = new byte[socket.ReceiveBufferSize];
      int numBytes = socket.Receive(receivedBytes);
      Console.WriteLine("Receiving...");
      receivedValue += Encoding.ASCII.GetString(receivedBytes);
      if (receivedValue.IndexOf("[FINAL]") > -1)
      {
        break;
      }
    }
