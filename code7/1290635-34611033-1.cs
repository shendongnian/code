    #if DEBUG
    container.ResolveOperationBeginning += (sender, e) =>
    {
        IComponentRegistration registration = null;
        e.ResolveOperation.InstanceLookupBeginning += (sender2, e2) =>
        {
            registration = e2.InstanceLookup.ComponentRegistration;
        };
        e.ResolveOperation.CurrentOperationEnding += (sender2, e2) =>
        {
            if (e2.Exception != null)
            {
                ConstructorInfo ci = registration.Activator.LimitType
                                                           .GetConstructors()
                                                           .First();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Can't instanciate {registration.Activator.LimitType}");
                foreach (ParameterInfo pi in ci.GetParameters())
                {
                    if (!((ILifetimeScope)sender).IsRegistered(pi.ParameterType))
                    {
                        sb.AppendLine($"\t{pi.ParameterType} {pi.Name} is not registered");
                    }
                }
                throw new DependencyResolutionException(sb.ToString(), e2.Exception);
            }
        };
    };
    #endif
