    public void ExecuteCommandOnThreadPool()
    {
        string host = "localhost";
        string user = "user";
        string pass = "1234";
        
        Action runCommand = () => 
        { 
            try 
            { 
               var client = new SshClient(host, user, pass);
               client.Connect();
                 var terminal = client.RunCommand("/bin/run.sh");
                 txtResult.Text = terminal.Result;
            } 
            finally 
            { 
                 client.Disconnect();
                 client.Dispose();
            } 
         };
        ThreadPool.QueueUserWorkItem(x => runCommand());
        }
    }
