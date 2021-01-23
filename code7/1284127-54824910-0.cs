    var connInfo = new Renci.SshNet.PasswordConnectionInfo("<IP>", 22, "<USER>", "<PWD>");
    var sshClient = new Renci.SshNet.SshClient(connInfo);
    
    sshClient.Connect();
    var stream = sshClient.CreateShellStream("", 0, 0, 0, 0, 0);
    
    // Send the command
    stream.WriteLine("echo 'sample command output'");
    
    // Read with a suitable timeout to avoid hanging
    string line;
    while((line = stream.ReadLine(TimeSpan.FromSeconds(2))) != null)
    {
        Console.WriteLine(line);
        // if a termination pattern is known, check it here and break to exit immediately
    }
    // ...
    stream.Close();
    // ...
    sshClient.Disconnect();
