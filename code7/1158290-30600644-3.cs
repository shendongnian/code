    public static IEnumerable<object[]> GetMappingObjects
    {
        get
        {
            return
                from r in Container.GetInstanceProducers()
                where IsAssignableToGenericType(r.ServiceType, typeof(IQueryMapping<,>))
                select new[] {r.GetInstance()};
        }
    }
    public static bool IsAssignableToGenericType(Type givenType, Type genericType)
    {
        while (true)
        {
            var interfaceTypes = givenType.GetInterfaces();
            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;
            if (interfaceTypes.Any(it => it.IsGenericType && it.GetGenericTypeDefinition() == genericType))
                return true;
            var baseType = givenType.BaseType;
            if (baseType == null)
                return false;
            givenType = baseType;
        }
    }
