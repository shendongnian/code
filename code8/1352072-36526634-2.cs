    System.Threading.Thread SocketThread;
    
        void Start()
        {
            startServer();
        }
    
        void startServer()
        {
            SocketThread = new System.Threading.Thread(networkCode);
            SocketThread.IsBackground = true;
            SocketThread.Start();
        }
    
        
        void networkCode()
        {
            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                // Program is suspended while waiting for an incoming connection.
                Socket handler = listener.Accept();
                data = null;
    
                // An incoming connection needs to be processed.
                while (true)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        return data;
                    }
    
                    System.Threading.Thread.Sleep(1);
                }
    
                System.Threading.Thread.Sleep(1);
            }
        }
    
        void stopServer()
        {
            //close socket here and clean up streams
    
    
    
            //Now stop thread
            if (SocketThread != null)
            {
                SocketThread.Abort();
                SocketThread.Join();
            }
        }
    
        void OnDisable()
        {
            stopServer();
        }
