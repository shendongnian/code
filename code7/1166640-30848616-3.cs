                CityRepository value = new CityRepository();
                Type type = value.GetType();
                Type baseType = type.BaseType;
                if (baseType.IsGenericType)
                {
                    Console.WriteLine(baseType.Name + " is generic type");
    
                    Type itemType = baseType.GetGenericArguments()[0];
                    Console.WriteLine("Generic argument: " + itemType.Name);
    
                    Type genericType = baseType.GetGenericTypeDefinition();
                    Console.WriteLine("Generic type: " + genericType.Name);
    
                    Console.WriteLine("Generic base type: " + genericType.BaseType.Name);
                }
    
                if (type.IsAssignableToGenericType(typeof(BaseRepository<>)))
                {
                    Console.WriteLine("IsAssignableToGenericType: BaseRepository<>");
                }
                
            if (type.IsAssignableToGenericType(typeof(InterventionBaseRepository<>)))
            {
                Console.WriteLine("IsAssignableToGenericType: InterventionBaseRepository<>");
            }
