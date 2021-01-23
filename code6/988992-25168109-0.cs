    public async Task ExecuteCommandAsync()
    {
        string host = "localhost";
        string user = "user";
        string pass = "1234";
        SshClient ssh = new SshClient(host, user, pass);
        using (var client = new SshClient(host, user, pass))
        {
            client.Connect();
            var terminal = await Task.Run(() => client.RunCommand("/bin/run.sh"));
            var output = terminal.Result;
            txtResult.Text = output;
            client.Disconnect();
        }
    }
