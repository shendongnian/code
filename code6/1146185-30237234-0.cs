    protected override void AttachToComponentRegistration(
        IComponentRegistry componentRegistry, IComponentRegistration registration)
    {
        registration.Preparing += (sender, args) =>
        {
            Console.WriteLine("Preparing {0}", registration.Activator
                                                           .LimitType
                                                           .GetPrettyName());
            args.Parameters = args.Parameters.Union(new[]
            {
                new ResolvedParameter(
                    predicate: (pi, c) => pi.ParameterType == typeof(ALogger), 
                    valueAccessor: (pi, c) =>
                    {
                        Parameter limitTypeParameter = null; 
                        IInstanceLookup lookup = c as IInstanceLookup; 
                        if(lookup != null)
                        {
                            String prettyName = lookup.ComponentRegistration
                                                      .Activator
                                                      .LimitType
                                                      .GetPrettyName();
                            limitTypeParameter = new NamedParameter("limitType", prettyName); 
                        }
                        else 
                        {
                            limitTypeParameter = new NamedParameter("limitType", null); 
                        }
                        return c.Resolve<ALogger>(limitTypeParameter); 
                    })
            });
        };
    }
