    When a `Owned<T>` service is activated a new `ILifetimeScope` will be created and its tag will be the associated service. 
        container.ChildLifetimeScopeBeginning += ChildLifetimeScopeBeginning;
        // ...
        private static void ChildLifetimeScopeBeginning(
            Object sender, LifetimeScopeBeginningEventArgs e)
        {
            e.LifetimeScope.ChildLifetimeScopeBeginning += ChildLifetimeScopeBeginning;
            IServiceWithType typedService = e.LifetimeScope.Tag as IServiceWithType;
            if (typedService != null && typedService.ServiceType == typeof(IBar))
            {
                e.LifetimeScope.Resolve<IFoo>();
            }
        }
