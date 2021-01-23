    private void ApplyCrossCuttingConcerns(UnityContainer container)
        {
            container.AddNewExtension<Interception>();
            container.RegisterType<IContact, Contact>(
                new InterceptionBehavior<PolicyInjectionBehavior>(),
                new Interceptor<InterfaceInterceptor>());
            container.Configure<Interception>()
                .AddPolicy("extensionPolicy")
                .AddMatchingRule<TypeMatchingRule>(new InjectionConstructor(new InjectionParameter(typeof(IContact))))
                .AddMatchingRule<MemberNameMatchingRule>(new InjectionConstructor(new InjectionParameter("Save")))
                .AddCallHandler<ExtensionHandler>(new ContainerControlledLifetimeManager(), new InjectionConstructor());
        }
