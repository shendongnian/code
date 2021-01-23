    void /*SecureManager.*/PerformOperation(
       string domain, string username, string password, Action<Server> action)
    {
       using (new Impersonation(domain, username, password))
       {
                action(new Server("serverInstance")); 
       }
    }
