      public bool DeleteRemoteDirectoryRecursive(string RemoteDirectoryPath)
        {
            if (string.IsNullOrEmpty(RemoteDirectoryPath))
            {                
                return false;
            }
            var ConnectionInfo = new ConnectionInfo(this.sftpHost, this.sftpPort, this.sftpUser, new PasswordAuthenticationMethod(this.sftpUser, this.sftpPassword));
            using (var client = new SftpClient(ConnectionInfo))
            {                
                client.Connect();
                if (!client.Exists(RemoteDirectoryPath))
                {                   
                    client.Disconnect();
                    client.Dispose();
                    return false;
                }
                foreach (var file in client.ListDirectory(RemoteDirectoryPath))
                {
                    if (file.Name.Equals(".") || file.Name.Equals(".."))
                        continue;
                    if (file.IsDirectory)
                    {
                        client.Disconnect();
                        DeleteRemoteDirectoryRecursive(file.FullName);
                    }
                    else
                        client.DeleteFile(file.FullName);
                }
                client.DeleteDirectory(RemoteDirectoryPath);
            }
            return true;
        }
        public bool Remove(string RemotePath)
        {
            bool ReturnResult = false;
            try
            {
                if (string.IsNullOrEmpty(RemotePath))
                {
                    return false;
                }
                var ConnectionInfo = new ConnectionInfo(this.sftpHost, this.sftpPort, this.sftpUser, new PasswordAuthenticationMethod(this.sftpUser, this.sftpPassword));
                using (var client = new SftpClient(ConnectionInfo))
                {
                    client.Connect();
                    if (!client.Exists(RemotePath))
                    {
                        client.Disconnect();
                        client.Dispose();
                        return false;
                    }
                 
                    try
                    {
                        //  path is directory
                        client.ChangeDirectory(RemotePath);
                        try
                        {
                            DeleteRemoteDirectoryRecursive(RemotePath);
                            ReturnResult = true;
                        }
                        catch
                        {
                            ReturnResult = false;
                        }
                    }
                    // path is a file
                    catch
                    {
                        try
                        {
                            client.DeleteFile(RemotePath);
                            ReturnResult = true;
                        }
                        catch
                        {
                            ReturnResult = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {                
                ReturnResult = false;
            }
            return ReturnResult;
        }
