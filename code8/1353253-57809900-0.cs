    public void CreateAllDirectories(SftpClient client, string path)
        {
            // Consistent forward slashes
            path = path.Replace(@"\", "/");
            foreach (string dir in path.Split('/'))
            {
                // Ignoring leading/ending/multiple slashes
                if (!string.IsNullOrWhiteSpace(dir))
                {
                    if(!client.Exists(dir))
                    {
                        client.CreateDirectory(dir);
                    }
                    client.ChangeDirectory(dir);
                }
            }
            // Going back to default directory
            client.ChangeDirectory("/");
        }
