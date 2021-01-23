    private string GetResponse(string command)
    {
        //Send request
        TcpClient client = new TcpClient(HOST, PORT);
        Byte[] data = Encoding.ASCII.GetBytes(command);
        NetworkStream stream = client.GetStream();
        stream.Write(data, 0, data.Length);
        //Read response
        data = new Byte[BUFFER_SIZE];
        String response = String.Empty;
        stream.ReadTimeout = READ_TIMEOUT;
        while (!response.EndsWith(RESPONSE_END))
        {
            int bytes = stream.Read(data, 0, data.Length);
            response += Encoding.ASCII.GetString(data, 0, bytes);
        }
        response = response.Remove(response.Length - RESPONSE_END.Length);
        stream.Close();
        client.Close();
        //Return
        return response;
    }
