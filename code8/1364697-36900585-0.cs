     public static IContainer WithWebApi(this IContainer container, HttpConfiguration config,
            IEnumerable<Assembly> controllerAssemblies = null, IScopeContext scopeContext = null,
            Func<Type, bool> throwIfUnresolved = null)
        {
            container.ThrowIfNull();
            if (container.ScopeContext == null)
                container = container.With(scopeContext: scopeContext ?? new AsyncExecutionFlowScopeContext());
                
            container.RegisterWebApiControllers(config, controllerAssemblies);
            container.SetFilterProvider(config.Services);
            InsertRegisterRequestMessageHandler(config);
            config.DependencyResolver = new DryIocDependencyResolver(container, throwIfUnresolved);
            return container;
        }
