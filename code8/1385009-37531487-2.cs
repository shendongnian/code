    String theMessageToReceive = Encoding.Unicode.GetString(bytes, 0, bytesRec);
        while (senderSock.Available > 0)
        {
          bytesRec = senderSock.Receive(bytes);
          theMessageToReceive += Encoding.Unicode.GetString(bytes, 0, bytesRec);
        // Do something
        }
