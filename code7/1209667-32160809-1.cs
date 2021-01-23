    public static void Initialize(Socket _MainSocket)
    {
        MainSocket = _MainSocket;
            
        AcceptGameConnection = new AsyncCallback(AddConnection);
        MainSocket.BeginAccept(result => {
            var userSocket = MainSocket.EndAccept(result);
            var thread = new Thread(AddConnection);
            thread.Start(userSocket);
            Initialize(MainSocket);
        }, null);
     }
 
     public static void AddConnection(IAsyncResult Result)
     {
         MainSocket.BeginAccept(AcceptGameConnection, null);
     }
     private static void AddConnection(Socket userSocket)
     {
         // Removed the stuff that happens to UserSocket because the same
         // symptoms occur regardless of their presence.
     }
