    IEnumerable<PropertyInfo> GetOneToManyRelationships<T>()
    {
        var collectionProps = from p in typeof(T).GetProperties()
                                where p.PropertyType.IsGenericType
                                    && p.PropertyType.GetGenericTypeDefinition() 
                                                                      == typeof(ICollection<>)
                                select p;
    
        foreach (var prop in collectionProps)
        {
            var type = prop.PropertyType.GetGenericArguments().First();
    
            // This checks if the other type has a One Property of this Type.
            bool HasOneProperty = type.GetProperties().Any(x => x.PropertyType == typeof(T));
    
            if (HasOneProperty)
            {
                yield return prop;
            }
        }
    }
