    public static class KernelExtensions
        {
            /// <summary>
            /// Binds an open generic type to its implementation and adds all its defined decorators
            /// </summary>
            /// <param name="kernel">Ninject Container</param>
            /// <param name="openGenericType">Open generic Type</param>
            /// <param name="assembly">Assembly to scan for the open generic type implementation</param>
            /// <param name="decoratorTypes">Types of the decorators. Order matters. Order is from the most outer decorator to the inner decorator</param>
            public static void BindManyOpenGenericsWithDecorators(this IKernel kernel, Type openGenericType, Assembly assembly, params Type[] decoratorTypes)
            {
                var allImplementations = GetAllTypesImplementingOpenGenericType(openGenericType, assembly);
    
                foreach (var type in allImplementations.Where(type => !decoratorTypes.Contains(type)))
                {
                    var genericInterface = type.GetInterfaces().FirstOrDefault(x => openGenericType.IsAssignableFrom(x.GetGenericTypeDefinition()));
    
                    // real implementation
                    var parentType = decoratorTypes.Last();
                    kernel.Bind(genericInterface).To(type)
                    .WhenInjectedInto(parentType);
                }
    
                for (var i = 0; i <= decoratorTypes.Count() - 1; i++)
                {
                    var decoratorType = decoratorTypes[i];
    
                    if (i == 0)
                    {
                        // most outer decorator
                        kernel.Bind(openGenericType).To(decoratorType);
                    }
                    else
                    {
                        // inner decorators
                        var parentType = decoratorTypes[i - 1];
                        kernel.Bind(openGenericType).To(decoratorType)
                            .WhenInjectedInto(parentType);
                    }
                }
            }
    
            private static IEnumerable<Type> GetAllTypesImplementingOpenGenericType(Type openGenericType, Assembly assembly)
            {
                return (from type in assembly.GetTypes()
                        from interfaceType in type.GetInterfaces()
                        let baseType = type.BaseType
                        where
                        (baseType != null && baseType.IsGenericType &&
                        openGenericType.IsAssignableFrom(baseType.GetGenericTypeDefinition())) ||
                        (interfaceType.IsGenericType &&
                        openGenericType.IsAssignableFrom(interfaceType.GetGenericTypeDefinition()))
                        select type);
            }
        }
