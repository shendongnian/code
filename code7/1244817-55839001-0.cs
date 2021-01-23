    using (var client = new SshClient("hostnameOrIp", "username", "password"))
    {
        client.Connect();
        client.RunCommand("...");
        client.Disconnect();
    }
