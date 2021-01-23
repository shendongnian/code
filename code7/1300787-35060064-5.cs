    static void Main(string[] args)
    {
        Console.WriteLine("Building Unity Container...");
        var container = (UnityContainer)UnityContainerBuilder.BuildDirectInUnity();
        Console.WriteLine("Listing Registrations...");
            
        FieldInfo policiesField = typeof(UnityContainer).GetFields(
                        BindingFlags.NonPublic |
                        BindingFlags.Instance).First(f => f.Name == "policies");
        FieldInfo parameterValuesField = typeof(SpecifiedConstructorSelectorPolicy).GetFields(
                        BindingFlags.NonPublic |
                        BindingFlags.Instance).First(f => f.Name == "parameterValues");
        FieldInfo paramNameField = typeof(ResolvedParameter).GetFields(
                        BindingFlags.NonPublic |
                        BindingFlags.Instance).First(f => f.Name == "name");
        var policies = (PolicyList)policiesField.GetValue(container);
        // build up a dictionary for loop below to use to get the lifetime manager
        var typeToRegistration = new Dictionary<Tuple<Type, string>, ContainerRegistration>();
        foreach (ContainerRegistration registration in container.Registrations)
        {
            typeToRegistration.Add(new Tuple<Type, string>(registration.RegisteredType, registration.Name), registration);
        }
        // now output the list
        foreach (ContainerRegistration registration in container.Registrations)
        {
            Console.WriteLine("{0} to {1}, {2}, {3}", 
                registration.RegisteredType.Name, 
                registration.MappedToType.Name, 
                registration.Name ?? "[default]",
                registration.LifetimeManagerType.Name);
            // need to check for our InjectionConstructor - I need local = false
            IConstructorSelectorPolicy constructorPolicy = policies.Get<IConstructorSelectorPolicy>(
                new NamedTypeBuildKey(registration.MappedToType, registration.Name), false);
            // and I need SpecifiedConstructorSelectorPolicy as we are not using the default constructor
            if (constructorPolicy is SpecifiedConstructorSelectorPolicy)
            {
                var specifiedConstructorPolicy = constructorPolicy as SpecifiedConstructorSelectorPolicy;
                // now output the ResolvedParameters for type, name, lifetime manager
                var paramValues = (InjectionParameterValue[])parameterValuesField.GetValue(specifiedConstructorPolicy);
                foreach (var param in paramValues)
                {
                    if (param is ResolvedParameter)
                    {
                        var resolvedParam = param as ResolvedParameter;
                        var name = (string)paramNameField.GetValue(resolvedParam);
                        string lifeTimeManagerName = 
                            typeToRegistration[new Tuple<Type, string>(resolvedParam.ParameterType, name)].LifetimeManagerType.Name;
                        Console.WriteLine("\t{0}, {1}, {2}", param.ParameterTypeName, name ?? "[default]", lifeTimeManagerName);
                    }
                    else
                    {
                        Console.WriteLine("\t{0}", param.ParameterTypeName);
                    }
                }
            }
        }
        Console.WriteLine("Complete");
        Console.ReadLine();
    }
