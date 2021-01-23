    private ServiceCallSite CreateConstructorCallSite(ResultCache lifetime, Type serviceType, Type implementationType,
        CallSiteChain callSiteChain)
    {
        try
        {
            callSiteChain.Add(serviceType, implementationType);
            var constructors = implementationType.GetTypeInfo()
                .DeclaredConstructors
                .Where(constructor => constructor.IsPublic)
                .ToArray();
            ServiceCallSite[] parameterCallSites = null;
            if (constructors.Length == 0)
            {
                throw new InvalidOperationException(Resources.FormatNoConstructorMatch(implementationType));
            }
            else if (constructors.Length == 1)
            {
                var constructor = constructors[0];
                var parameters = constructor.GetParameters();
                if (parameters.Length == 0)
                {
                    return new ConstructorCallSite(lifetime, serviceType, constructor);
                }
                parameterCallSites = CreateArgumentCallSites(
                    serviceType,
                    implementationType,
                    callSiteChain,
                    parameters,
                    throwIfCallSiteNotFound: true);
                return new ConstructorCallSite(lifetime, serviceType, constructor, parameterCallSites);
            }
            Array.Sort(constructors,
                (a, b) => b.GetParameters().Length.CompareTo(a.GetParameters().Length));
            ConstructorInfo bestConstructor = null;
            HashSet<Type> bestConstructorParameterTypes = null;
            for (var i = 0; i < constructors.Length; i++)
            {
                var parameters = constructors[i].GetParameters();
                var currentParameterCallSites = CreateArgumentCallSites(
                    serviceType,
                    implementationType,
                    callSiteChain,
                    parameters,
                    throwIfCallSiteNotFound: false);
                if (currentParameterCallSites != null)
                {
                    if (bestConstructor == null)
                    {
                        bestConstructor = constructors[i];
                        parameterCallSites = currentParameterCallSites;
                    }
                    else
                    {
                        // Since we're visiting constructors in decreasing order of number of parameters,
                        // we'll only see ambiguities or supersets once we've seen a 'bestConstructor'.
                        if (bestConstructorParameterTypes == null)
                        {
                            bestConstructorParameterTypes = new HashSet<Type>(
                                bestConstructor.GetParameters().Select(p => p.ParameterType));
                        }
                        if (!bestConstructorParameterTypes.IsSupersetOf(parameters.Select(p => p.ParameterType)))
                        {
                            // Ambiguous match exception
                            var message = string.Join(
                                Environment.NewLine,
                                Resources.FormatAmbiguousConstructorException(implementationType),
                                bestConstructor,
                                constructors[i]);
                            throw new InvalidOperationException(message);
                        }
                    }
                }
            }
            if (bestConstructor == null)
            {
                throw new InvalidOperationException(
                    Resources.FormatUnableToActivateTypeException(implementationType));
            }
            else
            {
                Debug.Assert(parameterCallSites != null);
                return new ConstructorCallSite(lifetime, serviceType, bestConstructor, parameterCallSites);
            }
        }
        finally
        {
            callSiteChain.Remove(serviceType);
        }
    }
