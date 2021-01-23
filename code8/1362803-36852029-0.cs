    private IConnection CreateConnection()
    {
        var connectionFactory = new ConnectionFactory
        {
            UserName = _userName,
            Password = _password,
            VirtualHost = _vhost,
            AutomaticRecoveryEnabled = DEFAULT_AUTO_RECOVER,
            RequestedHeartbeat = HEARTBEAT_TIMEOUT_SECONDS,
            Port = AmqpTcpEndpoint.UseDefaultPort,
            HostnameSelector = new RandomHostnameSelector()
        };
        // _hosts contains valid IPs "###.###.###.###"
        return connectionFactory.CreateConnection(_hosts);
    }
