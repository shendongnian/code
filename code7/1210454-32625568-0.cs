    SessionOptions sessionOptions= new SessionOptions
    {
        Protocol = Protocol.Sftp,
        HostName = "xxx.xxx.xxx.xxx",
        UserName = "root",
        Password = "MyPasword",
        SshHostKeyFingerprint = "ssh-rsa 2048 xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx"
    };
    
    private void WinScp(SessionOptions sessionOptions, string sourceFilePath, string destinationFilePath)
            {
                using (Session session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);
     
                    //// Upload files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;
     
                    TransferOperationResult transferResult;
                    transferResult = session.PutFiles(sourceFilePath, destinationFilePath, true, transferOptions);
     
                    //// Throw on any error
                    transferResult.Check();
                }
            }
 
