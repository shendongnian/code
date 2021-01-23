        public static class GenericClassifier
        {
            public static bool IsICollection(Type type)
            {
                return Array.Exists(type.GetInterfaces(), IsGenericCollectionType);
            }
        
            public static bool IsIEnumerable(Type type)
            {
                return Array.Exists(type.GetInterfaces(), IsGenericEnumerableType);
            }
        
            public static bool IsIList(Type type)
            {
                return Array.Exists(type.GetInterfaces(), IsListCollectionType);
            }
        
            static bool IsGenericCollectionType(Type type)
            {
                return type.IsGenericType && (typeof(ICollection<>) == type.GetGenericTypeDefinition());
            }
        
            static bool IsGenericEnumerableType(Type type)
            {
                return type.IsGenericType && (typeof(IEnumerable<>) == type.GetGenericTypeDefinition());
            }
        
            static bool IsListCollectionType(Type type)
            {
                return type.IsGenericType && (typeof(IList) == type.GetGenericTypeDefinition());
            }
        }
