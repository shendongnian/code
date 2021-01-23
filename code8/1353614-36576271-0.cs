    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
         
        // Download to a temporary folder
        string localPath = Path.GetTempFileName();
        session.GetFiles(remotePath, localPath).Check();
        
        // Read the file contents
        byte[] contents = File.ReadAllBytes(localPath);
        
        // Delete the temporary file
        File.Delete(localPath);
    }
