    public void AcceptCallback(IAsyncResult ar)
    {
        // Signal the main thread to continue.
        allDone.Set();
        // Get the socket that handles the client request.
        Socket listener = (Socket)ar.AsyncState;
        Socket handler = listener.EndAccept(ar);
        // Create the state object.
        ClientData state = new ClientData();
        state.workSocket = handler;
        clients.Add(state);
        handler.BeginReceive(state.buffer, 0, ClientData.BufferSize, 0,new AsyncCallback(ReadCallback), state);
        Console.WriteLine("we passed handler.BeginReceive");
        // Here, you must start a new accept:
        listener.BeginAccept(new AsyncCallback(AcceptCallback),listener);
    }
