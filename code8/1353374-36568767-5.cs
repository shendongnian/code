    private static void DeleteDirectory(SftpClient client, string path)
    {
        foreach (SftpFile file in client.ListDirectory(path))
        {
            if ((file.Name != ".") && (file.Name != ".."))
            {
                if (file.IsDirectory)
                {
                    DeleteDirectory(client, file.FullName);
                }
                else
                {
                    client.DeleteFile(file.FullName);
                }
            }
        }
        client.DeleteDirectory(path);
    }
