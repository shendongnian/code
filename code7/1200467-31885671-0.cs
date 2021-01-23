    private static void Run(string wsuri, string realmName)
    {
        using (IWampHost host = new DefaultWampHost(wsuri))
        {
            IWampHostedRealm realm = host.RealmContainer.GetRealmByName(realmName);
            realm.SessionCreated += SessionCreated;
            realm.SessionClosed += SessionRemoved;
    
            host.Open();
    
            Console.WriteLine("Server is running on " + wsuri);
    
            Console.ReadLine();
        }
    }
    
    private static void SessionCreated(object sender, WampSessionEventArgs wampSessionEventArgs)
    {
        Console.WriteLine("Client connected");
    }
    
    private static void SessionRemoved(object sender, WampSessionCloseEventArgs wampSessionCloseEventArgs)
    {
        Console.WriteLine("Client disconnected");
    }
