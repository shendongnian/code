    using (var client = new SshClient("hostnameOrIp", "username", "password"))
    {
        client.Connect();
        client.RunCommand("shutdown -h now;systemctl poweroff");
        client.Disconnect();
    }
