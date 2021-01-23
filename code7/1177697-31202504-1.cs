        class TestModule : Module
        {
            protected override void AttachToComponentRegistration(
                IComponentRegistry componentRegistry,
                IComponentRegistration registration)
            {
                if (registration.Services
                      .Any(s => s is IServiceWithType 
                                && ((IServiceWithType)s).ServiceType == typeof(IBar)))
                {
                    registration.Activated += (sender, e) =>
                    {
                        e.Context.Resolve<IFoo>();
                    };
                }
            }
        }
