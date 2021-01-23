    SessionOptions sessionOptions = new SessionOptions();
    sessionOptions.Protocol = Protocol.Ftp;
    sessionOptions.HostName = "hostname";
    sessionOptions.UserName = "username";
    sessionOptions.Password = "password";
    using (Session session = new Session())
    {
        session.Open(sessionOptions);
        foreach (RemoteFileInfo fileInfo in session.ListDirectory("/textures").Files)
        {
            if (fileInfo.Name.Contains("d"))
            {
                if (fileInfo.LastWriteTime > DateTime.Now.AddDays(-10))
                {
                    session.GetFiles(
                        session.EscapeFileMask("/textures/" + fileInfo.Name),
                        @"c:\local\path\").Check();
                }
            }
        }
    }
