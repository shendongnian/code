    StringBuilder fullResponse = new StringBuilder();
    byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
    int bytesRead;
    
    while ((bytesRead = serverStream.Read(buffer, 0, buffer.Length)) > 0)
    {
        string textRead = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead);
        fullResponse.Append(textRead);
    }
    
    xmlDoc.LoadXml(fullResponse.ToString());
