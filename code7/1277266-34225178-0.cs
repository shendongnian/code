    string host = "myhost";
    string user = "root";
    string pwd = "xyz##!"; // Don't use hardcoded plain-text passwords if possible - for demonstration only.
    
    using (PasswordAuthenticationMethod auth = new PasswordAuthenticationMethod(user, pwd))
    {
        ConnectionInfo connection = new ConnectionInfo(host, user, auth);
        using (var ssh = new SshClient(connection))
        {
            ssh.Connect();
            SshCommand sshCommand = ssh.RunCommand("pwd");
            Console.WriteLine("Command execution result: {0}", sshCommand.Result);
        }
    }
