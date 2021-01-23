    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Sftp,
        HostName = "example.com",
        UserName = "user",
        Password = "mypassword",
        SshHostKeyFingerprint = "ssh-rsa 2048 xxxxxxxxxxx...="
    };
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        // Delete the directory recursively
        session.RemoveFiles("/directory/to/delete").Check();
    }
