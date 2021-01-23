     Socket listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp );
        // Bind the socket to the local endpoint and listen for incoming connections.
        try {
            listener.Bind(localEndPoint);
            listener.Listen(100);
            while (true) {
                // Set the event to nonsignaled state.
                allDone.Reset();
                // Start an asynchronous socket to listen for connections.
                Console.WriteLine("Waiting for a connection...");
                listener.BeginAccept( 
                    new AsyncCallback(AcceptCallback),
                    listener );
                // Wait until a connection is made before continuing.
                allDone.WaitOne();
            }
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
