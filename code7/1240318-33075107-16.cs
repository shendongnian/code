    SessionOptions sessionOptions = new SessionOptions {
        Protocol = Protocol.Ftp,
        HostName = "example.com",
        UserName = "user",
        Password = "mypassword",
    };
    Session session = new Session();
    session.Open(sessionOptions);
