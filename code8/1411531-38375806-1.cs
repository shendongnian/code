    using (client = new SshClient("myserverproxy.net", "user", "password")) {
        client.KeepAliveInterval = new TimeSpan(0, 0, 60);
        client.ConnectionInfo.Timeout = new TimeSpan(0, 0, 20);
        client.Connect();
        port = new ForwardedPortDynamic("127.0.0.1", 20141);
        ...
    }
