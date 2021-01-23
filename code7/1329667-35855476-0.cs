    var factory = new ConnectionFactory();
    factory.UserName = "myuser";
    factory.Password = "mypassword";
    factory.VirtualHost = "/filestream";
    factory.Port = AmqpTcpEndpoint.UseDefaultPort;
    factory.HostName = "myserver";
