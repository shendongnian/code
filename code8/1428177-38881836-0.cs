    using(var scope = container.BeginLifetimeScope())
    {
        var registration = RegistrationBuilder.ForType<ServiceA>()
                                              .As<IService>()
                                              .CreateRegistration();
        scope.ComponentRegistry.Register(registration); 
        scope.Resolve<IService>(); 
    }
