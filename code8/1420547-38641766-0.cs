    public static void ReadCallback(IAsyncResult ar)
    {
        Console.WriteLine("ReadCallback");
        string content = string.Empty;
        // Retrieve the state object and the handler socket
        // from the asynchronous state object.
        StateObject state = (StateObject)ar.AsyncState;
        Socket handler = state.workSocket;
        // Read data from the client socket. 
        int bytesRead = handler.EndReceive(ar);
        if (bytesRead > 0)
        {
            // There  might be more data, so store the data received so far.
            state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
            // Check for end-of-file tag. If it is not there, read 
            // more data.
            content = state.sb.ToString();
            if (content.IndexOf("<EOF>") > -1)
            {
                // All the data has been read from the 
                // client. Display it on the console.
                Console.WriteLine("Read {0} bytes from socket. \n Data : {1}", content.Length, content);
                // continue reading
                state = new StateObject();
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                // I commented this out as when the send completes, the server closes the connection... I want the connection to remain open
                // Echo the data back to the client.
                //Send(handler, content);
            }
            else
            {
                // Not all data received. Get more
                // start writing at bytesRead in the buffer so you don't lose the partially read data
                handler.BeginReceive(state.buffer, bytesRead, StateObject.BufferSize, 0,
            new AsyncCallback(ReadCallback), state);
            }
        }
    }
