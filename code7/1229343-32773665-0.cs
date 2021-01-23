    var devices = GetDevices();
    foreach (var device in devices)
    {
        container.Register(
            Component.For<IMyService>()
                .ImplementedBy<MyService>()
                .Named("MyService:" + device.Name)
                .LifestyleSingleton()
                .DependsOn(Dependency.OnValue("devicePort", device.Port))
                .AsWcfService(new DefaultServiceModel()
                    .AddEndpoints(
                        WcfEndpoint
                            .BoundTo(binding)
                            .At(new EndpointAddress("net.tcp://localhost/MyService/" + device.Name)))
                ));
    }
