        static IEnumerable<PropertyInfo> GetICollectionOrICollectionOfTProperties(this Type type)
        {
            var interfaceProps =
                from prop in type.GetProperties()
                from interfaceType in prop.PropertyType.GetInterfaces()
                where interfaceType.IsGenericType
                let baseInterface = interfaceType.GetGenericTypeDefinition()
                where (baseInterface == typeof(ICollection<>)) || (baseInterface == typeof(ICollection))
                select prop;
            var nonInterfaceProps =
                from prop in type.GetProperties()
                where typeof(ICollection).IsAssignableFrom(prop.PropertyType) || typeof(ICollection<>).IsAssignableFrom(prop.PropertyType)
                select prop;
            return interfaceProps.Union(nonInterfaceProps);                
        }
