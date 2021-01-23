    ConnectionInfo myConnectionInfo =
        new ConnectionInfo(host, 22, username, new PasswordAuthenticationMethod(username, password)); 
    myConnectionInfo.Encoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
    using (var sftp = new SftpClient(myConnectionInfo))
    { 
        sftp.Connect();
        ....
    }
