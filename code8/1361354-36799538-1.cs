    public static class TypeExtensions
    {
        public static bool PropertyEquals(this PropertyInfo property, PropertyInfo other)
        {
             return property.DeclaringType == other.DeclaringType && property.Name == other.Name;
        }
    }
