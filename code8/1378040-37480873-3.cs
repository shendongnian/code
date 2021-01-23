    public void Configuration(IAppBuilder appBuilder)
    {
       var connectorBuilder = ConfigureConnector();
       var connector = connectorBuilder.Build(new OwinConnectorFactory());
       appBuilder.Map("/CKFinder/connector", builder => builder.UseConnector(connector));
    }
