    SshClient sshclient = new SshClient("172.0.0.1", userName, password);    
    sshclient.Connect();
    SshCommand sc= sshclient .CreateCommand("Your Commands here");
    sc.Execute();
    string answer = sc.Result;
