    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "ftp.example.com",
        UserName = "user",
        Password = "mypassword",
    };
 
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
 
        // Synchronize files
        session.SynchronizeDirectories(
            SynchronizationMode.Local, @"d:\www", "/home/martin/public_html", false).Check();
    }
 
