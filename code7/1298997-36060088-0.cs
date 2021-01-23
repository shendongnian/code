    KeyboardInteractiveAuthenticationMethod keybAuth = new KeyboardInteractiveAuthenticationMethod(SFTP_USR);
    keybAuth.AuthenticationPrompt += new EventHandler<AuthenticationPromptEventArgs>(HandleKeyEvent);
    
    ConnectionInfo conInfo = new ConnectionInfo(SFTP_HST, SFTP_PRT, SFTP_USR, keybAuth);
    
    using (SftpClient sftp = new SftpClient(conInfo))
    {
        sftp.Connect();
    
        // Do SFTP Stuff, Upload, Download,...
    
        sftp.Disconnect();
    }
