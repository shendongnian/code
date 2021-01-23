    try
    {
        SftpFileAttributes attrs = client.GetAttributes(current);
        if (!attrs.IsDirectory)
        {
            throw new Exception("not directory");
        }
    }
    catch (SftpPathNotFoundException)
    {
        client.CreateDirectory(current);
    }
