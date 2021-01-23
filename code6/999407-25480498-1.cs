    public void ReadCallback(IAsyncResult ar)
    {
        // Retrieve the state object and the handler socket
        // from the asynchronous state object.
        ClientData data = (ClientData)ar.AsyncState;
        String buff = String.Empty;
        Socket handler = data.workSocket;
        // Read data from the client socket. 
        int bytesRead = handler.EndReceive(ar);
        if (bytesRead > 0)
        {
            // There  might be more data, so store the data received so far.
            buff = Encoding.ASCII.GetString(data.buffer, 0, bytesRead);
            ParseBuffer(buff);
            Send(handler, "1");
            
            // Here, you need to Receive again
            handler.BeginReceive(state.buffer, 0, ClientData.BufferSize, 0,new AsyncCallback(ReadCallback), state);
        }
        if (bytesRead == 0) {
            CloseConnection(handler);
        }
    }   
