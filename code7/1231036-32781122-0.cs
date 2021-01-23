    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Sftp,
        HostName = "example.com",
        UserName = "user",
        Password = "mypassword",
        SshHostKeyFingerprint = "ssh-rsa 2048 xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx"
    };
    
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
    
        const string remotePath = "/path";
        // Tetrieve a list of files in a remote directory
        RemoteDirectoryInfo directory = session.ListDirectory(remotePath);
    
        // Iterate the list
        foreach (RemoteFileInfo fileInfo in directory.Files)
        {
            // Is it a file with .txt extension?
            if (!fileInfo.IsDirectory &&
                fileInfo.Name.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                string tempPath = Path.GetTempFileName();
                // Download the file to a temporary folder
                session.GetFiles(session.EscapeFileMask(remotePath + "/" + fileInfo.Name), tempPath).Check();
                // Read the contents
                string[] lines = File.ReadAllLines(tempPath);
                // Retrieve what you need from lines
                ...
                // Delete the temporary copy
                File.Delete(tempPath);
            }
        }
    }
