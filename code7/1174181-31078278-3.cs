    // Buffer to store the response bytes.
    data = new Byte[256];
    // String to store the response ASCII representation.
    String responseData = String.Empty;
    // Read the first batch of the TcpServer response bytes.
    Int32 bytes = stream.Read(data, 0, data.Length); //(**This receives the data using the byte method**)
    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes); //(**This converts it to string**)
