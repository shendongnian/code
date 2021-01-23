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
        // Download files
        session.GetFiles("/directory/to/download/*", @"C:\target\directory\*").Check();
    }
