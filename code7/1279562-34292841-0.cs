    container.Register(
        Types
            .FromAssemblyContaining<ILoginService>()
            .BasedOn<IService>()
            .If(s => s.Name.EndsWith("Service"))
            .Configure(
                configurer => configurer
                    .AsWcfClient(new DefaultClientModel
                    {
                        Endpoint = WcfEndpoint.BoundTo(new BasicHttpBinding { MaxReceivedMessageSize = 3000000 })
                            .At(string.Format("http://localhost:{0}/{1}.svc", Port, configurer.Implementation.Name.Substring(1)))
                    })));
