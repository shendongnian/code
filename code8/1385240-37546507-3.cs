    public static class UnityExtensions
    {
        public static void RegisterValidators(this IUnityContainer container)
        {
            var types = AllClasses.FromLoadedAssemblies().GetValidators();
            foreach (var type in types)
            {
                var interfaces = WithMappings.FromAllInterfaces(type);
                foreach (var @interface in interfaces)
                {
                    container.RegisterType(@interface, type);
                }
            }
        }
        
        public static IEnumerable<Type> GetValidators(this IEnumerable<Type> types)
        {
            var wantedType = typeof(IValidator<>);
            return from type in types 
                   from interfaceType in type.GetInterfaces() 
                   where interfaceType.IsGenericType 
                        && !interfaceType.ContainsGenericParameters 
                        && wantedType.IsAssignableFrom(interfaceType.GetGenericTypeDefinition()) 
                   select type;
        }
    }
