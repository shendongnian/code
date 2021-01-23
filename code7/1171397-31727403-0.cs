        container.AddFacility<WcfFacility>();
        foreach (var wcfType in types.Where(t => t.IsInterface == false && t.IsAbstract == false)) // types should be coming from AppDomain.Current assemblies
        {
            foreach (var anInterface in wcfType.GetInterfaces().Where(anInterface => anInterface
                .GetCustomAttributes(typeof(ServiceContractAttribute), true).Any()))
            {
                var serviceModel = new DefaultServiceModel().Hosted();
                container.Register(Component.For(anInterface)
                                            .ImplementedBy(wcfType)
                                            .AsWcfService(serviceModel)
                        );
            }
        }
