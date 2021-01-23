    builder.RegisterType<Engine>()
    .           As<IEngine>()
        .InstancePerDependency();
    
    builder.RegisterType<SshConnection>()
        .Keyed<IConnection>(ConnectionType.Ssh);
    builder.RegisterType<TelnetConnection>()
        .Keyed<IConnection>(ConnectionType.Telnet);
