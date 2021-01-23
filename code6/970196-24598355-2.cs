        static IEnumerable<PropertyInfo> GetICollectionOrICollectionOfTProperties(this Type type)
        {    
            // Get properties with PropertyType declared as interface
            var interfaceProps =
                from prop in type.GetProperties()
                from interfaceType in prop.PropertyType.GetInterfaces()
                where interfaceType.IsGenericType
                let baseInterface = interfaceType.GetGenericTypeDefinition()
                where (baseInterface == typeof(ICollection<>)) || (baseInterface == typeof(ICollection))
                select prop;
            // Get properties with PropertyType declared(probably) as solid types.
            var nonInterfaceProps =
                from prop in type.GetProperties()
                where typeof(ICollection).IsAssignableFrom(prop.PropertyType) || typeof(ICollection<>).IsAssignableFrom(prop.PropertyType)
                select prop;
            // Combine both queries into one resulting
            return interfaceProps.Union(nonInterfaceProps);                
        }
