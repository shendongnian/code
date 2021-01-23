    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "example.com",
        UserName = "username",
        Password = "password",
    };
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        // Get list of files in the directory
        string remotePath = "/remote/path/";
        RemoteDirectoryInfo directoryInfo = session.ListDirectory(remotePath);
        // Select the most recent file
        RemoteFileInfo latest =
            directoryInfo.Files
                .OrderByDescending((file) => file.LastWriteTime)
                .First();
        // Download the selected file
        localPath = @"C:\local\path\";
        session.GetFiles(session.EscapeFileMask(remotePath + latest.Name), localPath).Check();
    }
