    public static class MembersProvider
    {
        public static IEnumerable<PropertyInfo> GetProperties(Type type, params string[] names)
        {
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty)
                .Where(pi => names.Contains(pi.Name))
                .Where(pi => pi != null)
                .AsEnumerable();
            if (names.Count() != properties.Count())
            {
                throw new InvalidOperationException("Couldn't find all properties on type " + type.Name);
            }
    
            return properties;
        }
    }
