        private void CreateServerDirectoryIfItDoesntExist(string serverDestinationPath, SftpClient sftpClient)
        {
            if (serverDestinationPath[0] == '/')
                serverDestinationPath = serverDestinationPath.Substring(1);
          
            string[] directories = serverDestinationPath.Split('/');
            for (int i = 0; i < directories.Length; i++)
            {
                string dirName = string.Join("/", directories, 0, i + 1);
                if (!sftpClient.Exists(dirName))
                    sftpClient.CreateDirectory(dirName);
            }
        }
