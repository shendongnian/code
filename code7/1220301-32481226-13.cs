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
                    string sourcePath =
                        RemotePath.EscapeFileMask("/textures/" + fileInfo.Name);
                    session.GetFiles(sourcePath, @"c:\local\path\").Check();
                }
            }
        }
    }
