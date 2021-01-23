    kernel.AddFacility<TypedFactoryFacility>();
    kernel.Register(
                    Component.For<ICmsServiceFactory>()
                             .AsFactory()
                   );
