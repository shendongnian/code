    Bind<IConnection>()
        .ToMethod(ctx =>
                    {
    var connectionString = configurationManager.ConnectionStrings["RabbitMQ"].ConnectionString;
                        var factory = new ConnectionFactory
                                    {
                                        Uri = ConnectionString,
                                        RequestedHeartbeat = 15,
                                        //every N seconds the server will send a heartbeat.  If the connection does not receive a heartbeat within
                                        //N*2 then the connection is considered dead.
                                        //suggested from http://public.hudl.com/bits/archives/2013/11/11/c-rabbitmq-happy-servers/
                                        AutomaticRecoveryEnabled = true
                                    };
    
                        return factory.CreateConnection();
                    })
        .InSingletonScope();
