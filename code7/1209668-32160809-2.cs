    public static void Initialize(Socket mainSocket)
    {           
        while(true)
        {
            var userSocket = await Task.Factory.FromAsync(
                                    mainSocket.BeginAccept,
                                    mainSocket.EndAccept);
            ThreadPool.QueueUserWorkItem(_ => AddConnection(userSocket));
        }
     }
     private static void AddConnection(Socket userSocket)
     {
         // Removed the stuff that happens to UserSocket because the same
         // symptoms occur regardless of their presence.
     }
