    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "example.com",
        UserName = "user",
        Password = "mypassword",
    };
    
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
    
        // Upload
        session.PutFiles(@"c:\toupload\file.txt*", "/home/user/").Check();
    }
