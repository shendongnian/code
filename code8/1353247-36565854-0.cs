    static public void CreateDirectoryRecursively(this SftpClient client, string path)
    {
        string current = "";
        if (path[0] == '/')
        {
            path = path.Substring(1);
        }
        while (!string.IsNullOrEmpty(path))
        {
            int p = path.IndexOf('/');
            current += '/';
            if (p >= 0)
            {
                current += path.Substring(0, p);
                path = path.Substring(p + 1);
            }
            else
            {
                current += path;
                path = "";
            }
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
        }
    }
