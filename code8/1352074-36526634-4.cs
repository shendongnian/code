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
           //Initialize socket here and streams here
           socket .......new ....
           socket accept....
            
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
        }
    
        void stopServer()
        {
            //stop thread
            if (SocketThread != null)
            {
                SocketThread.Abort();
                SocketThread.Join();
            }
            //Now close socket and streams here and clean up streams
            .........
        }
    
        void OnDisable()
        {
            stopServer();
        }
