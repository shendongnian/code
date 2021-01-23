    builder.Register(c => c.Resolve<IConfigurationService>()
                           .GetConfig<Protocol1Configuration>())
           .As<Protocol1Configuration>(); 
    builder.RegisterType<Protocol1>()
           .Named<IProtocol1>(nameof(Protocol1))
           .WithParameter((pi, c) => pi.ParameterType == typeof(IFramingAgent), 
                          (pi, c) => c.ResolveNamed<IFramingAgent>(nameof(Protocol1))
           .WithParameter((pi, c) => pi.ParameterType == typeof(IFramingAlgorithm), 
                          (pi, c) => c.ResolveNamed<IFramingAlgorithm>(nameof(Protocol1));
    builder.RegisterType<FramingAgentProtocol1>()
           .Named<IFramingAgent>(nameof(Protocol1));
    builder.RegisterType<FramingAlgorithmProtocol1>()
           .Named<IFramingAlgorithm>(nameof(Protocol1));
