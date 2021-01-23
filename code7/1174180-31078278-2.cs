    // Translate the passed message into ASCII and store it as a Byte array.
    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);         
    // Get a client stream for reading and writing. 
    NetworkStream stream = client.GetStream();
    // Send the message to the connected TcpServer. 
    stream.Write(data, 0, data.Length); //(**This is to send data using the byte method**)   
    
