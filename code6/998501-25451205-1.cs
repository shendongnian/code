    Component.For<IWcfContract>()
        .ImplementedBy<WcfContractClient>()
        .DependsOn(new
        {
            binding = MyConfig.NetTcpBinding,
            remoteAddress = new EndpointAddress(MyConfig.WcfHostAddressAndPort)
        })
    .LifestyleTransient()),
    Component.For<IWcfContractClientFactory>()
        .AsFactory(new WcfContractClientFactorySelector())
