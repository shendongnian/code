    if (client.Exists(current))
    {
        SftpFileAttributes attrs = client.GetAttributes(current);
        if (!attrs.IsDirectory)
        {
            throw new Exception("not directory");
        }
    }
    else
    {
        client.CreateDirectory(current);
    }
