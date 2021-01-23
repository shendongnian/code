    SessionOptions sessionOptions = new SessionOptions();
    sessionOptions.Protocol = Protocol.Ftp;
    sessionOptions.HostName = "hostname";
    sessionOptions.UserName = "username";
    sessionOptions.Password = "password";
    
    using (Session session = new Session())
    {
        session.Open(sessionOptions);
        session.GetFiles("/textures/*d*>=10D", @"c:\local\path\").Check();
    }
