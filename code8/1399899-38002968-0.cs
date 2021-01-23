    Socket s = yoursocket;
    MemoryStream bufferStream = new MemoryStream();
    byte[] buffer = new byte[1024];
    int count;
    // Keep reading blocks from the stream until there is no more data being received.
    // As specified in the docs, Receive will block until there is data - or the end of the
    // stream has been reached.
    while((count = s.Receive(buffer)) != 0)
    {
        // Write all received bytes into the buffer stream
        // (which is an in memory byte stream)
        bufferStream.Write(buffer, 0, count);
    }
    
    // Get the entire byte array from the stream
    byte[] entireData = bufferStream.ToArray();
    
    // Convert the received data to a string using ascii encoding
    string receivedDataAsString = System.Text.Encoding.ASCII.GetString(entireData);
