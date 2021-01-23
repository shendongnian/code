     // Create a Tcp listener.
     mTcpListener = new TcpListener(theAddress, port);
     Console.WriteLine($"Trying to listen on {theAddress}:{port}");
     mTcpListener.Start();
     Console.WriteLine("Listening...");
     Socket socket = null;
     try
     {
         socket = mTcpListener.AcceptSocket();
     }
     catch (Exception ex)
     {
         Console.WriteLine(ex.Message);
         return;
     }
     // wait a little for the socket buffer to fill up
     await Task.Delay(20);
     int bytesAvailable = socket.Available;
     var completeBuffer = new List<byte>();
     while (bytesAvailable > 0)
     {
         byte[] buffer = new byte[bytesAvailable];
         int bytesRead = socket.Receive(buffer);
         completeBuffer.AddRange(buffer.Take(bytesRead));
         bytesAvailable = socket.Available;
     }
     byte[] receivedBytes = completeBuffer.ToArray();
     string receivedString = Encoding.ASCII.GetString(receivedBytes);
