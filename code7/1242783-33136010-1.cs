    public class SFTPConnectionService : IDisposable
    {
    
        private SftpClient sftp;
        private SftpFileStream file;
    
        public SftpFileStream GetRemoteFile(string filename)
        {
            // Server credentials
            var host = "host";
            var port = 22;
            var username = "username";
            var password = "password";
    
            sftp = new SftpClient(host, port, username, password);
    
            // Connect to the SFTP server
            sftp.Connect();
    
            // Read the file in question
            file = sftp.OpenRead(filename);
    
            return file;
        }
        // Recommended implementation of IDisposable:
        public void Dispose()
        {
            Dispose(true);
        
            // Use SupressFinalize in case a subclass 
            // of this type implements a finalizer.
            GC.SuppressFinalize(this);   
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) 
                {
                    if(sftp != null)
                         sftp.Dispose();
                    if(file != null)
                         file.Dispose();
                }
        
                // Indicate that the instance has been disposed.
                _disposed = true;   
            }
        }
    }
