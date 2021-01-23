        public static IEnumerable<PropertyInfo> ExtractTypeProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                   BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
        }
