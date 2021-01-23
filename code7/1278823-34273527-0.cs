    private static Session OpenSession()
    {
        SessionOptions sessionOptions = new SessionOptions
        {
            Protocol = Protocol.Sftp,
            HostName = @"server",
            UserName = "name",
            PortNumber = 22,
            SshHostKeyFingerprint = "ssh-rsa 2048 RSAKEY",
        };
        // Connect
        session.Open(sessionOptions);
        return session;
    }
