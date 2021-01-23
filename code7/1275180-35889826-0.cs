    using (var sftp = new SftpClient(sFTPServer, sFTPPassword, sFTPPassword))
    {
         sftp.Connect();
    
         // Load remote file into a stream
         var remoteFileStream = sftp.OpenRead("file.txt");
         System.IO.TextReader textReader = new System.IO.StreamReader(remoteFileStream);
         string s = textReader.ReadToEnd(); 
         sftp.Disconnect()
    }
