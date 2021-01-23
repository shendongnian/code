    sender.Connect(remoteEP);
    Console.WriteLine("Socket connected to {0}",
        sender.RemoteEndPoint.ToString());
    // Encode the data string into a byte array.
    byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");
    // Send the data through the socket.
    int bytesSent = sender.Send(msg);
    // Receive the response from the remote device.
    int bytesRec = sender.Receive(bytes);
    Console.WriteLine("Echoed test = {0}",
        Encoding.ASCII.GetString(bytes,0,bytesRec));
    // Release the socket.
    sender.Shutdown(SocketShutdown.Both);
    sender.Close();
