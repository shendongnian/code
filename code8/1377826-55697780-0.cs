    public void DeleteDirectory(string path)
        {
            using (var sftp = new SftpClient(ost, Settings.Instance.Deployment_user, Settings.Instance.Deployment_password))
            {
                sftp.Connect();
                foreach (SftpFile file in sftp.ListDirectory(path))
                {
                    if ((file.Name != ".") && (file.Name != ".."))
                    {
                        if (file.IsDirectory)
                        {
                            DeleteDirectory(file.FullName);
                        }
                        else
                        {                          
                            file.Delete();
                        }
                    }
                }
                sftp.DeleteDirectory(path);
                sftp.Disconnect();
            }
        }
